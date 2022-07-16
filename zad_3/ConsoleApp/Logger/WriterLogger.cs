using System;
using System.IO;

namespace ConsoleApp.Logger
{
    public abstract class WriterLogger: ILogger
    {
        protected TextWriter? writer;

        public virtual void Log(params string[] messages)
        {
            DateTime dateTime = DateTime.Now;
            writer.Write(dateTime + " ");
            foreach (string message in messages)
            {
                writer.Write(message + " ");
            }
            writer.Write("\n");
            writer.Flush();

        }
        public abstract void Dispose();
    }
}
