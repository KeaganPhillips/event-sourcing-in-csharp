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
    public class DeactiveCustomerCommandHandler : ICommandHandler<DeactiveCustomerCommand, Customer>
    {
        public IEnumerable<IEvent> Handle(DeactiveCustomerCommand command, Customer customer)
        {
            return new IEvent[]
            {
                new CustomerDeactivatedEvent(customer.Id)
            };
        }
    }
}
