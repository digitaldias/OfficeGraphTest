using OfficeGraphTest.Domain.Contracts;
using System;
using System.Diagnostics;

namespace OfficeGraphExplorer
{
    public class Logger : ILogger
    {
        public void LogError(string errorMessage)
        {
            Debug.WriteLine("ERROR: " + errorMessage);
        }


        public void LogException(Exception exception)
        {
            Debug.WriteLine("EXCPETION>> " + exception.Message);
        }


        public void logWarning(string warningMessage)
        {
            Debug.WriteLine("Warning: " + warningMessage);
        }
    }
}
