using System;
using System.Collections.Generic;

namespace ES.Core.Events
{
    public interface IEventRepo
    {
        IEnumerable<IAggregateEvent> FetchAggregateEvent(Guid aggregateId);
        void PersistEvent(IEvent @event);
    }
}