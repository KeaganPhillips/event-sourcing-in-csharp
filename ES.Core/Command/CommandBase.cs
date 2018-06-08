using Newtonsoft.Json;
using System;

namespace ES.Core.Command
{
    public abstract class CommandBase : ICommand
    {
        public Guid CommandId { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime ClientDateTimeCreated { get; private set; }
        public DateTime DateTimeReceived  { get; private set; }
        public string Identity { get; private set; }

        public CommandBase(Guid commandId, DateTime datetimeCreated, Guid aggregateId,
            string identity)
        {
            this.CommandId = commandId;
            this.ClientDateTimeCreated = datetimeCreated;
            this.DateTimeReceived = DateTime.Now;
            this.AggregateId = aggregateId;
            this.Identity = identity;
        }
    }
}