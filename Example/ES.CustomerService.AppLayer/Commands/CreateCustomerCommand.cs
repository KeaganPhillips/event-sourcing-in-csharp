using ES.Core.Command;
using ES.CustomerService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.AppLayer.Commands
{
    public class CreateCustomerCommand : CommandBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }

        public CreateCustomerCommand(Guid commandId, DateTime datetimeCreated, string identity) 
            : base(commandId, datetimeCreated, Guid.NewGuid(), identity) // <-- New Customer, so create new GUID
        {
        }
    }
}
