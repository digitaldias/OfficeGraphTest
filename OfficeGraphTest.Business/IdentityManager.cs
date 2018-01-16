using Microsoft.IdentityModel.Clients.ActiveDirectory;
using OfficeGraphTest.Domain.Contracts;
using System;

namespace OfficeGraphTest.Business
{
    public class IdentityManager : IIdentityManager
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ISettings _settings;
        private string _bearerToken;

        public IdentityManager(IExceptionHandler exceptionHandler, ISettings settings)
        {
            _exceptionHandler = exceptionHandler;
            _settings         = settings;
        }


        public string BearerToken => _bearerToken;


        public bool SignIn(string resource)
        {
            var authority             = _settings["authority"];
            var authenticationContext = new AuthenticationContext(authority);
            var clientId              = _settings["applicationId"];
            var redirectUri           = new Uri(_settings["redirectUri"]);

            var parameters = new PlatformParameters(PromptBehavior.Auto);

            // Clear any cached tokens every time for now 
            authenticationContext.TokenCache.Clear();

            var token = authenticationContext.AcquireTokenAsync(resource, clientId, redirectUri, parameters).Result;

            _bearerToken = "Bearer " + token.AccessToken;

            return true;
        }
    }
}
