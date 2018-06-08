using System;

namespace ES.Core.Events
{
    public interface IEvent            
    {        
        Guid EventId { get; }
        DateTime DateCreate { get; }
    }
}