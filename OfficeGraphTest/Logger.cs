using OfficeGraphTest.Domain.Contracts;
using System;

namespace OfficeGraphTest
{
    /// <summary>
    /// Dummy implementation of the ILogger interface
    /// </summary>
    public class Logger : ILogger
    {
        public void LogError(string errorMessage)
        {
            Console.WriteLine($"ERROR: {errorMessage}");
        }


        public void LogException(Exception exception)
        {
            Console.WriteLine($"EXCEPTION>> {exception.Message} <<<");
        }


        public void logWarning(string warningMessage)
        {
            Console.WriteLine($"Warning: {warningMessage}");
        }
    }
}
