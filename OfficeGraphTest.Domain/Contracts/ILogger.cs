using System;

namespace OfficeGraphTest.Domain.Contracts
{
    public interface ILogger
    {
        void LogException(Exception exception);

        void LogError(string errorMessage);

        void logWarning(string warningMessage);
    }
}