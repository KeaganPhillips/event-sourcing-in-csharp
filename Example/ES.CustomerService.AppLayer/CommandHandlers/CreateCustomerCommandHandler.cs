using ES.Core.Command;
using ES.Core.Events;
using ES.CustomerService.AppLayer.Commands;
using ES.CustomerService.Domain;
using ES.CustomerService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.AppLayer.CommandHandlers
{
    internal class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Customer>
    {
        public IEnumerable<IEvent> Handle(CreateCustomerCommand command, Customer aggregate)
        {
            return new List<IEvent>()
            {
                new CustomerCreatedEvent(aggregate.Id)
                {
                    Name = command.Name,
                    Surname = command.Surname,
                    Address = command.Address,
                    Status = CustomerStatus.Active
                }
            };
        }
    }
}
