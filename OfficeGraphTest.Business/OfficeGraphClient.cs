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
        private readonly ISettings _settings;

        public OfficeGraphClient(IExceptionHandler exceptionHandler, ILogger logger, IIdentityManager identityManager,  IOfficeGraphReader officeGraphReader, ISettings settings)
        {
            _exceptionHandler  = exceptionHandler;
            _logger            = logger;

            _identityManager   = identityManager;
            _officeGraphReader = officeGraphReader;
            _settings          = settings;
        }


        public bool Initialize()
        {
            if(_identityManager == null)
            {
                _logger.LogError("IdentityManager Is null");
                return false;
            }

            var signInSuccess = _exceptionHandler.Get(() => 
                _identityManager.SignIn(_settings["officeGraphResource"])
             );            

            if(!signInSuccess)
            {
                _logger.LogError("Unable to sign in successfully");
                return false;
            }
            return signInSuccess;
        }


        public async Task<ContactList> GetMyContactsAsync()
        {
            return await _exceptionHandler.GetAsync(async () =>
            {
                var contactsAsJson = await _officeGraphReader.GetMyContactsAsync(_identityManager.BearerToken);

                if (!string.IsNullOrEmpty(contactsAsJson))
                {
                    return JsonConvert.DeserializeObject<ContactList>(contactsAsJson);
                }
                return null;
            });
        }


        public async Task<byte[]> GetMyImageBytesAsync()
        {
            return await _exceptionHandler.GetAsync(() => 
                _officeGraphReader.GetImageBytesAsync(_identityManager.BearerToken)
            );
        }


        public async Task<GraphUser> GetMyInformationAsync()
        {
            if (!_identityManager.IsSignedIn)
                return null;

            var graphUserAsJson = await _exceptionHandler.GetAsync(() =>
                _officeGraphReader.GetMyInformationAsync(_identityManager.BearerToken)
            );

            if (string.IsNullOrEmpty(graphUserAsJson))
                return null;

            return JsonConvert.DeserializeObject<GraphUser>(graphUserAsJson);
        }


        public async Task SignOut()
        {
            var wasSignedOut = await _exceptionHandler.GetAsync( async () => {
                return await Task.Run(() => _identityManager.SignOut());
            });

            if (!wasSignedOut)
            {
                _logger.logWarning("Something went wrong when signing out");
            }           
        }
    }
}
