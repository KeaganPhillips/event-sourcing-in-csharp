using ES.Core.Events;
using ES.CustomerService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.ApplyEvent
{
    public class ApplyCustomerCreatedEvent_v1 : IApplyEvent<CustomerCreatedEvent, Customer>
    {
        public int EventVersion => 1;

        public Customer Apply(Customer customer, CustomerCreatedEvent @event)
        {
            customer.FirstName = @event.Name;
            customer.Surname = @event.Surname;
            customer.Address = @event.Address;
            customer.Status = @event.Status;

            return customer;
        }
    }
}
