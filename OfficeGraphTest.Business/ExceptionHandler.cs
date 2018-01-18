using OfficeGraphTest.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace OfficeGraphTest.Business
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;


        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }


        public TResult Get<TResult>(Func<TResult> unsafeFunction)
        {
            if (unsafeFunction == null)
                throw new ArgumentNullException(nameof(unsafeFunction));
            try
            {
                return unsafeFunction.Invoke();
            }
            catch (AggregateException aex)
            {
                _logger.LogException(aex.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            return default(TResult);
        }


        public Task<TResult> GetAsync<TResult>(Func<Task<TResult>> unsafeAsyncFunction)
        {
            if (unsafeAsyncFunction == null)
                throw new ArgumentNullException(nameof(unsafeAsyncFunction));
            try
            {
                return unsafeAsyncFunction.Invoke();
            }
            catch (AggregateException aex)
            {
                _logger.LogException(aex.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            return Task.FromResult(default(TResult));
        }


        public void Run(Action unsafeAction)
        {
            if (unsafeAction == null)
                throw new ArgumentNullException(nameof(unsafeAction));

            try
            {
                unsafeAction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
        }


        public async Task RunAsync(Func<Task> unsafeAsyncFunc)
        {
            if (unsafeAsyncFunc == null)
                throw new ArgumentNullException(nameof(unsafeAsyncFunc));

            try
            {
                await unsafeAsyncFunc.Invoke();
            }
            catch (AggregateException aex)
            {
                _logger.LogException(aex.InnerException);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }                        
        }
    }
}
