
using System;

namespace ThomasJude.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine(message);
        }
    }
}
