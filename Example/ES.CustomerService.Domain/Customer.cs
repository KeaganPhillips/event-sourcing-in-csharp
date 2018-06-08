using System;
using ES.Core.Aggregate;

namespace ES.CustomerService.Domain
{
    public class Customer : AggregateRootBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }

        public Customer(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}