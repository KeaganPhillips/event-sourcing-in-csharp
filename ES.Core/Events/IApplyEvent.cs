using ES.Core.Aggregate;

namespace ES.Core.Events
{
    public interface IApplyEvent<E, A> 
        where E: IAggregateEvent
        where A: IAggregateRoot
    {
        int EventVersion { get; }
        A Apply(A aggregate, E @event);
    }
}