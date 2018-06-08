using System;

namespace ES.Core.Command
{
    public interface ICommand
    {
        /// <summary>
        /// Client Side command ID
        /// </summary>
        Guid CommandId { get; }

        /// <summary>
        /// The Date/Time this command was created on the client
        /// </summary>
        DateTime ClientDateTimeCreated { get; }

        /// <summary>
        /// The aggregate id to mutate
        /// </summary>
        Guid AggregateId { get; }

        /// <summary>
        /// The user/identity issuing the command
        /// </summary>
        string Identity { get; }
        
    }
}