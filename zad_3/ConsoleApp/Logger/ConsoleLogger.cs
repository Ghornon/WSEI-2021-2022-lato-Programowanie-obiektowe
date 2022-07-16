using System;
using System.IO;

namespace ConsoleApp.Logger
{
    public class ConsoleLogger : WriterLogger
    {

        public ConsoleLogger()
        {
            writer = Console.Out;
        }
        public override void Dispose()
        {
           
        }
        
    }
}
