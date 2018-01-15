using OfficeGraphTest.Domain.Contracts;
using OfficeGraphTest.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OfficeGraphTest.Business
{
    public class OfficeGraphClient : IOfficeGraphClient
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger _logger;

        public OfficeGraphClient(IExceptionHandler exceptionHandler, ILogger logger)
        {
            _exceptionHandler = exceptionHandler;
            _logger           = logger;
        }


        public Task<GraphUser> GetMyInformationAsync()
        {
            throw new NotImplementedException();
        }


        public bool Initialize(IIdentityManager identityManager)
        {
            if(identityManager == null)
            {
                _logger.LogError("IdentityManager Is null");
                return false;
            }

            var signInSuccess = identityManager.SignIn();            

            if(!signInSuccess)
            {
                _logger.LogError("Unable to sign in successfully");
                return false;
            }
            return signInSuccess;
        }
    }
}
