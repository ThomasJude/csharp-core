using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace thomasjude.core.HttpClient
{
    public interface IHttpClient
    {
        Task<HttpResponse> GetAsync(string resource);
    }

    public interface IHttpResponse
    {
        String Content { get; set; }
        HttpStatusCode StatusCode { get; set; }
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }
    }
}