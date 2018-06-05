using System;
using ES.Core.Aggregate;

namespace ES.CustomerService.Domain
{
    public class Customer : IAggregateRoot
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }
    }
}