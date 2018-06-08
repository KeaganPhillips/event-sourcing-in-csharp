using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Command.CommandEvents
{
    public class CommandFulfilledEvent : IEvent
    {
        public Guid EventId => Guid.NewGuid();

        public DateTime DateCreate => DateTime.Now;

        public Guid CommandId { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime DateTimeFulfilled { get; private set; }        

        public CommandFulfilledEvent(ICommand command)
        {
            this.CommandId = command.CommandId;
            this.AggregateId = command.AggregateId;
            this.DateTimeFulfilled = DateTime.Now;
        }
    }
}
