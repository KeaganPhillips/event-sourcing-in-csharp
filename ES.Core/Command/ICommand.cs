using System;

namespace ES.Core.Command
{
    public interface ICommand
    {
        Guid CommandId { get; }
        Guid AggregateId { get; }
        DateTime DateTimeCreated { get;  }                
        DateTime DateTimeReceived  { get; }
        DateTime? DateTimeRejected { get;  }                
        DateTime? DateTimeFulfilled { get; }
        Exception Exception { get; }
    }
}