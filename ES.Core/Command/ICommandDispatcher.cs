using ES.Core.Aggregate;
using ES.Core.Events;

namespace ES.Core.Command
{
    public interface ICommandDispatcher<A>
        where A : class, IAggregateRoot
        
    {
        void Dispatch<C>(C command)
            where C : CommandBase;
    }
}