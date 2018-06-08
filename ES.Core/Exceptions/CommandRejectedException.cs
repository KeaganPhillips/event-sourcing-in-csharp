using ES.Core.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Core.Exceptions
{
    public class CommandRejectedException : ApplicationException
    {
        public string SerializeCommand { get; private set; }

        public CommandRejectedException(string message, Exception ex)
            :base(message, ex)
        {
        }
    }
}
