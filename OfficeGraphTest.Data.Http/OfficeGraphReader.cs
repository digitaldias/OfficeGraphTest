using OfficeGraphTest.Domain.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OfficeGraphTest.Data.Http
{
    public class OfficeGraphReader : IOfficeGraphReader
    {
        private const string VERSION          = "beta";
        private const string PATH_ME          = "me";
        private const string PATH_ME_IMAGE    = "me/photo/$value";
        private const string PATH_ME_CONTACTS = "me/contacts";


        private readonly ISettings _settings;
        private readonly Uri _resourceUri;
        private HttpClient _httpClient;


        public OfficeGraphReader(ISettings settings)
        {
            _settings    = settings;
            _resourceUri = new Uri(_settings["officeGraphResource"]);
            _httpClient  = new HttpClient();
        }


        public async Task<byte[]> GetImageBytesAsync(string bearerToken)
        {
            Uri finalUri = ConstructFinalGraphUri(bearerToken, PATH_ME_IMAGE);

            var responseMessage = await _httpClient.GetAsync(finalUri);
            if(responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsByteArrayAsync();
            }
            return null;
        }


        public async Task<string> GetMyContactsAsync(string bearerToken)
        {
            Uri finalUri = ConstructFinalGraphUri(bearerToken, PATH_ME_CONTACTS);

            var responseMessage = await _httpClient.GetAsync(finalUri);

            if(responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            return null;
        }


        public async Task<string> GetMyInformationAsync(string bearerToken)
        {
            Uri finalUri = ConstructFinalGraphUri(bearerToken, PATH_ME);

            var responseMessage = await _httpClient.GetAsync(finalUri);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }


        private Uri ConstructFinalGraphUri(string bearerToken, string method)
        {
            var finalUri = new Uri($"{_settings["officeGraphResource"]}/{VERSION}/{method}/");

            _httpClient.DefaultRequestHeaders.Remove("authorization");
            _httpClient.DefaultRequestHeaders.Add("authorization", bearerToken);
            return finalUri;
        }
    }
}
