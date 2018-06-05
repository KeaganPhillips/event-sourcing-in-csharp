using System;

namespace ES.Core.Command
{
    public abstract class CommandBase : ICommand
    {
        public Guid CommandId { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime DateTimeCreated { get; private set; }
        public DateTime DateTimeReceived  { get; private set; }
        public DateTime? DateTimeRejected { get; private set; }                
        public DateTime? DateTimeFulfilled { get; private set; }
        public Exception Exception { get; set; }

        public CommandBase(Guid commandId, DateTime datetimeCreated, Guid aggregateId)
        {
            this.CommandId = commandId;
            this.DateTimeCreated = datetimeCreated;
            this.DateTimeReceived = DateTime.Now;
            this.AggregateId = aggregateId;
        }

        public void Reject(Exception ex)
        {
            this.DateTimeRejected = DateTime.Now;
            this.DateTimeFulfilled = null;
            this.Exception = ex;
        }

        public void Successful()
        {
            this.DateTimeFulfilled = DateTime.Now;
            this.DateTimeRejected = null;
            this.Exception = null;
        }
        
    }
}