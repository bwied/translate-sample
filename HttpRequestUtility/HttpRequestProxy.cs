using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpRequestUtility
{
    public class HttpRequestProxy<T> : IHttpRequestProxy where T: HttpRequestDto
    {
        private readonly HttpClient _client;

        protected T Request { get; }
        protected Uri Uri => new Uri($"{Request.Scheme}://{Request.Host}/{string.Join("?", Request.Route, Query)}");
        protected string Query => string.Join("&", Request.Parameters);

        protected HttpRequestProxy(HttpClient client, T request)
        {
            _client = client;
            Request = request;
        }

        public async Task<HttpResponse<TResponse>> Send<TResponse>()
        {
            using (var httpRequest = GetRequestMessage())
            {
                // Send the request and get response.
                HttpResponseMessage response = await _client.SendAsync(httpRequest).ConfigureAwait(false);

                return new HttpResponse<TResponse>() { Response = response };
            }
        }

        private HttpRequestMessage GetRequestMessage()
        {
            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethodRegistry.Instance[Request.Method](),
                RequestUri = Uri,
                Content = Request.Body
            };

            Request.Headers.ToList().ForEach(x => httpRequest.Headers.Add(x.Key, x.Value));

            return httpRequest;
        }
    }
}