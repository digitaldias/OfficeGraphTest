using OfficeGraphTest.Domain.Contracts;
using System;
using System.Diagnostics;

namespace OfficeGraphTest
{
    /// <summary>
    /// Dummy implementation of the ILogger interface
    /// </summary>
    public class Logger : ILogger
    {
        public void LogException(Exception exception)
        {
            Debug.WriteLine($"EXCEPTION>> {exception.Message} <<<");
        }
    }
}
