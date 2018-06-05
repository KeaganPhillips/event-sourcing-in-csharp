using System.Collections.Generic;
using ES.Core.Aggregate;
using ES.Core.Events;

namespace ES.Core.Command
{
    public interface ICommandHandler<C, A> 
            where C: CommandBase   
            where A: IAggregateRoot
    {
        IEnumerable<IEvent> Handle(C command, A aggregate);
    } 
}