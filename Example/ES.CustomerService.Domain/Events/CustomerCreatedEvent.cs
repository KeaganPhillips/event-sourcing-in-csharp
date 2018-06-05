using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.Events
{
    public class CustomerCreatedEvent : AggregateEventBase
    {
        public override int Version => 1;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }

        public CustomerCreatedEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
