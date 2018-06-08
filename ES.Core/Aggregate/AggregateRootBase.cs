using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Aggregate
{
    public class AggregateRootBase : IAggregateRoot
    {
        public Guid Id { get; private set; }

        public int AggregateVersion { get; private set; }

        public AggregateRootBase(Guid aggregateId)
        {
            this.Id = aggregateId;
            this.AggregateVersion = 0;
        }

        public void IncrementAggregateVersion()
        {
            this.AggregateVersion++;
        }
    }
}
