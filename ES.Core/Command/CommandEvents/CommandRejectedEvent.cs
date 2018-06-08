using ES.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Command.CommandEvents
{
    public class CommandRejectedEvent : IEvent
    {
        public Guid EventId => Guid.NewGuid();
        public DateTime DateCreate => DateTime.Now;
        public Guid CommandId { get; }
        public Guid AggregateId { get; }
        public DateTime DateTimeRejected { get; }
        public Exception Exception { get; }

        public CommandRejectedEvent(ICommand command, Exception ex)        
        {
            this.CommandId = command.CommandId;
            this.AggregateId = command.AggregateId;
            this.DateTimeRejected = DateTime.Now;
            this.Exception = ex;
        }
    }
}
