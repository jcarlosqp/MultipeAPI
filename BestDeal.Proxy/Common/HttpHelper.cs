using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BestDeal.Proxy.Common
{
    public class HttpHelper : IHttpHelper
    {
        private readonly HttpClient _httpClient;
        private const string JSON_MEDIA_TYPE = "application/json";
        private const string XML_MEDIA_TYPE = "application/xml";

        public HttpHelper(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON_MEDIA_TYPE));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(XML_MEDIA_TYPE));

        }

        public async Task<TResult> GetAsync<TResult>(Uri url, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            try
            {
                TResult result = default;

                var response = await _httpClient.GetAsync($"{url}{parameters.ToList().ConvertToQueryString()}");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.ContentAsType<TResult>();
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }

                return result;
            }
            catch (Exception ex)
            {
                // log exception
                throw;
            }
        }
    }
}
