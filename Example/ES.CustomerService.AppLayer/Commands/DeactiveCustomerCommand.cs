using ES.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.AppLayer.Commands
{
    public class DeactiveCustomerCommand : CommandBase
    {
        public DeactiveCustomerCommand(Guid commandId, DateTime datetimeCreated, Guid aggregateId, string identity) 
            : base(commandId, datetimeCreated, aggregateId, identity)
        {
        }
    }
}
