using ES.Core.Events;
using ES.CustomerService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.ApplyEvent
{
    public class ApplyCustomerCreatedEvent_v2 : IApplyEvent<CustomerCreatedEvent, Customer>
    {
        public int EventVersion => 2;

        public Customer Apply(Customer aggregate, CustomerCreatedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
