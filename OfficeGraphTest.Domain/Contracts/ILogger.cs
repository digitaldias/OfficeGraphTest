using System;

namespace OfficeGraphTest.Domain.Contracts
{
    public interface ILogger
    {
        void LogException(Exception exception);
    }
}