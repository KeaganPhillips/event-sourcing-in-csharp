using ES.Core.Events;
using ES.CustomerService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.ApplyEvent
{
    public class ApplyEventCustomerDeactivated : IApplyEvent<CustomerDeactivatedEvent, Customer>
    {
        public int EventVersion => 1;

        public Customer Apply(Customer customer, CustomerDeactivatedEvent @event)
        {
            customer.Status = CustomerStatus.Inavtive;
            return customer;
        }
    }
}
