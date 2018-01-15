using System;
using System.Threading.Tasks;

namespace OfficeGraphTest.Domain.Contracts
{
    public interface IExceptionHandler
    {
        void Run(Action unsafeAction);


        Task RunAsync(Func<Task> unafeAsyncFunc);


        TResult Get<TResult>(Func<TResult> unsafeFunction);


        Task<TResult> GetAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction);
    }
}
