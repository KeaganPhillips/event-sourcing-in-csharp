using ES.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.CustomerService.Infrastructure.Logging
{
    /// <summary>
    /// Maybe create a Log4Net logger or a logger logging staight to logstash??
    /// </summary>
    public class DummyLogger : ILogger
    {
        public void Debug(string message)
        {
        }

        public void Error(string message, Exception ex)
        {
        }

        public void Info(string message)
        {
        }

        public void Warning(string message)
        {
        }
    }
}
