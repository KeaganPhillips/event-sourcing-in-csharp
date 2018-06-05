using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ES.CustomerService.Repository
{
    /// <summary>
    /// In memory Event store for now
    /// </summary>
    public class CustomerEventRepo : IEventRepo
    {
        private List<IEvent> _eventStore = new List<IEvent>();

        public IEnumerable<IAggregateEvent> FetchAggregateEvent(Guid aggregateId)
        {
            // Return all the events for this aggregate
            return _eventStore
               .Where(e => e is IAggregateEvent)
               .Select(e => e as IAggregateEvent)
               .Where(e => e.AggregateId == aggregateId)
               .OrderBy(e => e.DateCreate);
        }

        public void PersistEvent(IEvent @event)
        {
            _eventStore.Add(@event);
        }
    }
}
