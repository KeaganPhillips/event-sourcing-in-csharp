using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Events
{
    public interface IAggregateEvent : IEvent
    {
        Guid AggregateId { get; }
    }
}
