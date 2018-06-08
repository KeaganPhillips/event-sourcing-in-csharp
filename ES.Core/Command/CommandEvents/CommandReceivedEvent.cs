using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Command.CommandEvents
{
    public class CommandReceivedEvent : IEvent
    {

        public Guid EventId => new Guid();
        public DateTime DateCreate => DateTime.Now;

        public string CommandName { get; }
        public string CommandType { get; }
        public Guid CommandId { get; }
        public Guid AggregateId { get; }
        public DateTime DateTimeCreatedAtClient { get; }
        public DateTime DateTimeReceived { get; }
        public string Identity { get; }
        public ICommand OriginalCommand { get; }

        public CommandReceivedEvent(ICommand command)
        {
            this.CommandName = command.GetType().Name;
            this.CommandType = command.GetType().FullName;
            this.CommandId = command.CommandId;
            this.AggregateId = command.AggregateId;
            this.DateTimeCreatedAtClient = command.ClientDateTimeCreated;
            this.DateTimeReceived = DateTime.Now;
            this.Identity = command.Identity;
            this.OriginalCommand = command;
        }
    }
}
