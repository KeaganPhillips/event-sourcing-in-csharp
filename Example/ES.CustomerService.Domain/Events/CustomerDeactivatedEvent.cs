using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.Events
{
    public class CustomerDeactivatedEvent : AggregateEventBase
    {
        public override int Version => 1;

        public CustomerDeactivatedEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
