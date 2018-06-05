using System;

namespace ES.Core.Events
{
    public interface IEvent            
    {
        int Version { get; }
        Guid EventId { get; }
        DateTime DateCreate { get; }
    }
}