using System;
using System.Collections.Generic;
using ES.Core.Events;

namespace ES.Core.Aggregate
{
    public interface IAggregateRoot
    {
        /// <summary>
        /// The unique ID for a given aggregate instance
        /// </summary>
        /// <returns></returns>
        Guid Id { get; }

        /// <summary>
        /// A state transision counter 
        /// </summary>
        /// <returns></returns>
        int AggregateVersion { get; }
    }
}