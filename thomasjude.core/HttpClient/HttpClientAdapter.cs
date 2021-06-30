
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using http = System.Net.Http.HttpClient;

namespace thomasjude.core.HttpClient
{
    public class HttpClientAdapter : IHttpClient
    {
        private readonly http _http;
        private readonly String _baseUrl;

        public HttpClientAdapter(string baseUrl)
        {
            _http = new http();
            _baseUrl = baseUrl;
        }

        public async Task<HttpResponse> GetAsync(string resource)
        {
            var response = await _http.GetAsync(_baseUrl + resource);
            var result = await MapToHttpResponse(response);
            return result;
        }

        // helpers
        private async Task<HttpResponse> MapToHttpResponse(HttpResponseMessage response)
        {         
            var result = new HttpResponse
            {
                Content = await response.Content.ReadAsStringAsync(),
                StatusCode = response.StatusCode,
                Headers = response.Headers
            };
            return result;
        }
    }

    public class HttpResponse : IHttpResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }
    }
}