using System;

namespace ES.Core.Aggregate
{
    public interface IAggregateFactory<A> where A: IAggregateRoot
    {
        /// <summary>
        /// Called when creating the initial instance, before applying events
        /// </summary>
        /// <param name="aggreateId"></param>
        /// <returns></returns>
        A Init(Guid aggreateId);
    }
}