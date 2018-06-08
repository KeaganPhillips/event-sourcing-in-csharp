using ES.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.AppLayer.Commands
{
    public class UpdateAddressCommand : CommandBase
    {
        public string NewAddressDetails { get; set; }

        public UpdateAddressCommand(Guid commandId, DateTime datetimeCreated, Guid aggregateId, string identity) 
            : base(commandId, datetimeCreated, aggregateId, identity)
        {
        }
    }
}
