using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Events
{
    public interface IAggregateEvent : IEvent
    {
        int Version { get; }
        Guid AggregateId { get; }
    }
}
