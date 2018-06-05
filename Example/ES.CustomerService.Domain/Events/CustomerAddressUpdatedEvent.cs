using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.Events
{
    public class CustomerAddressUpdatedEvent : AggregateEventBase
    {
        public override int Version => 1;
        public string NewAddress { get; set; }

        public CustomerAddressUpdatedEvent(Guid aggregateId, string newAddress) : base(aggregateId)
        {
            this.NewAddress = newAddress;
        }
    }
}
