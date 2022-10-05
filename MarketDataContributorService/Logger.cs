using System;

namespace MarketDataContributorService
{
    public class Logger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void LogDebug(string message)
        {
            Console.WriteLine($"Debug: {message}");
        }
    }
}
