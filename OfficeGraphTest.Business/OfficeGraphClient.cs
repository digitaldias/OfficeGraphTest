using Newtonsoft.Json;
using OfficeGraphTest.Domain.Contracts;
using OfficeGraphTest.Domain.Entities;
using System.Threading.Tasks;

namespace OfficeGraphTest.Business
{
    public class OfficeGraphClient : IOfficeGraphClient
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger _logger;
        private readonly IIdentityManager _identityManager;
        private readonly IOfficeGraphReader _officeGraphReader;
        

        public OfficeGraphClient(IExceptionHandler exceptionHandler, ILogger logger, IIdentityManager identityManager,  IOfficeGraphReader officeGraphReader)
        {
            _exceptionHandler  = exceptionHandler;
            _logger            = logger;

            _identityManager   = identityManager;
            _officeGraphReader = officeGraphReader;
        }


        public async Task<GraphUser> GetMyInformationAsync()
        {
            var graphUserAsJson = await _exceptionHandler.GetAsync(() =>
                _officeGraphReader.GetMyInformationAsync(_identityManager.BearerToken)
            );

            if (string.IsNullOrEmpty(graphUserAsJson))
                return null;

            return JsonConvert.DeserializeObject<GraphUser>(graphUserAsJson);
        }


        public bool Initialize()
        {
            if(_identityManager == null)
            {
                _logger.LogError("IdentityManager Is null");
                return false;
            }

            var signInSuccess = _exceptionHandler.Get(() => 
                _identityManager.SignIn()
             );            

            if(!signInSuccess)
            {
                _logger.LogError("Unable to sign in successfully");
                return false;
            }
            return signInSuccess;
        }
    }
}
