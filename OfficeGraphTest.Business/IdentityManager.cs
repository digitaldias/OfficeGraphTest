using Microsoft.IdentityModel.Clients.ActiveDirectory;
using OfficeGraphTest.Domain.Contracts;
using System;
using System.Net.Http;

namespace OfficeGraphTest.Business
{
    public class IdentityManager : IIdentityManager
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ISettings         _settings;
        private string                     _bearerToken;
        private AuthenticationContext      _authenticationContext;


        public IdentityManager(IExceptionHandler exceptionHandler, ISettings settings)
        {
            _exceptionHandler = exceptionHandler;
            _settings         = settings;
        }


        public string BearerToken => _bearerToken;


        public bool IsSignedIn => string.IsNullOrEmpty(_bearerToken) == false;


        public bool SignIn(string resource)
        {
            if (string.IsNullOrEmpty(resource))
                throw new ArgumentNullException(nameof(resource));

            var authority             = _settings["authority"];
            var clientId              = _settings["applicationId"];
            var redirectUri           = new Uri(_settings["redirectUri"]);

            _authenticationContext = new AuthenticationContext(authority);
            var parameters = new PlatformParameters(PromptBehavior.Auto);


            var token = _authenticationContext.AcquireTokenAsync(resource, clientId, redirectUri, parameters).Result;

            _bearerToken = "Bearer " + token.AccessToken;

            return true;
        }


        public bool SignOut()
        {
            var logoutUri = new Uri($"{_settings["authority"]}/oauth2/logout?post_logout_redirect_uri={_settings["redirectUri"]}");

            _authenticationContext.TokenCache.Clear();

            var client   = new HttpClient();
            var request  = new HttpRequestMessage(HttpMethod.Get, logoutUri);
            var response = client.SendAsync(request).Result;

            //TODO: I don't feel logged out in spite of a success code...
            if(response.IsSuccessStatusCode)
            {
                _bearerToken = string.Empty;
                return true;
            }
            return false;
        }
    }
}
