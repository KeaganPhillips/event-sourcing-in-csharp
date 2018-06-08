using System;
using System.Collections.Generic;
using System.Linq;
using ES.Core.Aggregate;
using ES.Core.Command.CommandEvents;
using ES.Core.Events;
using ES.Core.Exceptions;
using ES.Core.Logging;
using ES.Core.ServiceLocation;

namespace ES.Core.Command
{
    public class CommandDispatcher<A> : ICommandDispatcher<A> 
        where A: AggregateRootBase
    {
        #region Dependencies
        private readonly IServiceLocator _serviceLocator;
        private readonly IEventRepo _eventRepo;
        private readonly IAggregateFactory<A> _aggreageFactory;
        private readonly ILogger _log;
        #endregion

        public CommandDispatcher(IServiceLocator serviceLocator, IEventRepo eventRepo,
            IAggregateFactory<A> aggreageFactory, ILogger log)
        {
            _eventRepo = eventRepo;
            _serviceLocator = serviceLocator;
            _aggreageFactory = aggreageFactory;
            _log = log;
        }
        public void Dispatch<C>(C command) 
                where C : CommandBase          
        {
            try
            {
                // Log the fact that we received a command
                _eventRepo.PersistEvent(new CommandReceivedEvent(command));

                // Load the Aggreage
                var initAggregate = _aggreageFactory.Init(command.AggregateId);
                var aggregate = (A)_eventRepo
                                    .FetchAggregateEvent(command.AggregateId) // <-- Fetch events from repo
                                    .Aggregate(initAggregate, _applyEvent); // <-- Reduce the array of events to an AggregateRoot with the current state                

                // Command handler to create new events
                var newEvents = _serviceLocator
                    .Resolve<ICommandHandler<C, A>>()
                    .Handle(command, aggregate)
                    .ToList();

                // Apply the newly created events we got from the command handler
                newEvents
                    .Where(e => e is IAggregateEvent) // Only apply Aggreage Events
                    .Select(e => e as IAggregateEvent)
                    .ToList()
                    .ForEach(e => _applyEvent(aggregate, e));

                // Persist newly created events
                newEvents.ForEach(_eventRepo.PersistEvent);

                // Mark the command as successful
                _eventRepo.PersistEvent(new CommandFulfilledEvent(command));

                // Log
                _log.Info($"Command {command.CommandId} Succesful");
            }
            catch (Exception ex)
            {
                // Log the rejected command
                _eventRepo.PersistEvent(new CommandRejectedEvent(command, ex));
                var msg = $"Command Rejected. CommandId: {command.CommandId}. {ex.Message}";
                _log.Error(msg, ex);             
                throw new CommandRejectedException(msg, ex);
            }
        }

        private A _applyEvent(A aggregate, IAggregateEvent @event)
        {
            //TODO: Probably better ways to do then. Don't like the casting and reflection           

            // Get the event handler
            var t = typeof(IApplyEvent<,>).MakeGenericType(@event.GetType(), typeof(A));
            var handlersForEvent =_serviceLocator.GetInstances(t).ToList();

            if (handlersForEvent.Count == 0)
                throw new NotImplementedException("No IApplyEvent found for type: " + t.FullName);

            // Get the IApplyEvent that matches this IEvent.Version
            var correctVersionHandlers = handlersForEvent.Where(h =>
                {
                    var versionProp = t.GetProperty("EventVersion");
                    return (int)versionProp.GetValue(h) == @event.Version;
                }).ToList();

            // Thow if there where no implementations for this version of the event
            if(correctVersionHandlers.Count == 0)
                throw new NotImplementedException($"No implementations of IApplyEvent found for type: '{t.FullName}' with version: {@event.Version}");

            // Thow if there where multiple Apply implementaions for this verions of the event
            if (correctVersionHandlers.Count > 1)
                throw new NotImplementedException($"Multiple implementations of IApplyEvent found for type: '{t.FullName}' and version: {@event.Version}");

            // Apply the event and return the new aggregate state
            var handler = correctVersionHandlers.First(); // <-- Only 1 IApplyEvent for this version :-)            

            // Kee the old aggregate version number
            var initialAggVersion = aggregate.AggregateVersion;

            // Apply
            var getMethod = t.GetMethod("Apply");
            var updatedAggregate = (A)getMethod.Invoke(handler, new object[] { aggregate, @event });

            // make sure the developer didn't change the aggergate version.
            if (initialAggVersion != updatedAggregate.AggregateVersion)
                throw new ApplicationException("Aggregate version changed. Handlers should not update the aggarate version.");

            // Up the Aggregate  version. Only the command dispatcher should up the aggregate version
            aggregate.IncrementAggregateVersion();

            // Newly updated aggregate :-)
            return updatedAggregate;
        }
    }
}