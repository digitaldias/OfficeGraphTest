using OfficeGraphTest.Domain.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OfficeGraphTest.Data.Http
{
    public class OfficeGraphReader : IOfficeGraphReader
    {
        private const string VERSION = "v1.0";
        private const string PATH_ME = "me";


        private readonly ISettings _settings;
        private readonly Uri _resourceUri;
        private HttpClient _httpClient;


        public OfficeGraphReader(ISettings settings)
        {
            _settings    = settings;
            _resourceUri = new Uri(_settings["officeGraphResource"]);
            _httpClient  = new HttpClient();
        }


        public async Task<string> GetMyInformationAsync(string bearerToken)
        {
            var finalUri = new Uri($"{_settings["officeGraphResource"]}/{VERSION}/{PATH_ME}/");

            _httpClient.DefaultRequestHeaders.Remove("authorization");
            _httpClient.DefaultRequestHeaders.Add("authorization", bearerToken);

            var responseMessage = await _httpClient.GetAsync(finalUri);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }
    }
}
