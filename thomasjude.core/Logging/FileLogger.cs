
using System;
using System.IO;

namespace thomasjude.core.Logging
{
    public class FileLogger : ILogger
    {
        private readonly String _logFilePath;

        public FileLogger(String logFilePath)
        {
            _logFilePath = logFilePath;
        }
        
        public void Log(String message)
        {
            File.AppendAllText(_logFilePath, message + Environment.NewLine); 
        }
    }
}
