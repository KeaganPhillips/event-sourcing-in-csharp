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
    class UpdateAddressCommandHandler : ICommandHandler<UpdateAddressCommand, Customer>
    {
        public IEnumerable<IEvent> Handle(UpdateAddressCommand command, Customer customer)
        {
            return new IEvent[]
            {
                new CustomerAddressUpdatedEvent(command.AggregateId, command.NewAddressDetails)
            };
        }
    }
}
