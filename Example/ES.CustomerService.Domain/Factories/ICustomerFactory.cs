using ES.Core.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Domain.Factories
{
    public class ICustomerFactory : IAggregateFactory<Customer>
    {
        public Customer Init(Guid aggreateId)
        {
            return new Customer(aggreateId)
            {
                FirstName = null,
                Surname = null,
                Address = null                
            };
        }
    }
}
