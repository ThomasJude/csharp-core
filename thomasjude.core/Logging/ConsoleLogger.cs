
using System;

namespace thomasjude.core.Logging
{
  public class ConsoleLogger : ILogger
  {
    public void Log(String message)
    {
      Console.WriteLine(message);
    }
  }
}