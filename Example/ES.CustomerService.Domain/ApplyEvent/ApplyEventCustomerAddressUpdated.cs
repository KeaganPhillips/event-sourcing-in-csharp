using ES.Core.Events;
using ES.CustomerService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.ApplyEvent
{
    public class ApplyEventCustomerAddressUpdated : IApplyEvent<CustomerAddressUpdatedEvent, Customer>
    {
        public int EventVersion => 1;

        public Customer Apply(Customer customer, CustomerAddressUpdatedEvent @event)
        {
            customer.Address = @event.NewAddress;
            return customer;
        }
    }
}
