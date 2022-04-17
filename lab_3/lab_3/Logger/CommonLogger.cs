using System;

namespace ConsoleApp.Logger
{
    public class CommonLogger : ILogger
    {
        private ILogger[] loggers;

        public CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public void Dispose()
        {
        }

        public void Log(params string[] messages)
        {
            foreach (var logger in loggers)
            {
                logger.Log(messages);
            }
        }
    }
}