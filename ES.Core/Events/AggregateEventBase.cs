using System;

namespace ES.Core.Events
{
    public abstract class AggregateEventBase : IAggregateEvent
    {
        public Guid AggregateId { get; private set; }
        public abstract int Version { get; }       
        public Guid EventId { get; private set; }
        public DateTime DateCreate { get; private set; }        

        public AggregateEventBase(Guid aggregateId)
        {
            this.AggregateId = aggregateId;
            this.EventId = Guid.NewGuid();
            this.DateCreate = DateTime.Now;
        }
    }
}