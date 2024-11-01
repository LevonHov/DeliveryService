using System;
using System.IO;

namespace Delivery_Service.Services
{
    public class LogService
    {
        private readonly string _logFilePath;

        public LogService(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public void LogError(string message)
        {
            Log("ERROR", message);
        }

        public void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        private void Log(string severity, string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{severity}] {message}";
            try
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true)) 
                {
                    writer.WriteLine(logEntry);
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }

        }
    }
}
