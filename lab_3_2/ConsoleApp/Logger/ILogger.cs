using System;

namespace ConsoleApp.Logger
{
    public interface ILogger : IDisposable
    {
        public void Log(params string[] messages);
    }
}