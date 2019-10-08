using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpRequestUtility
{
    public class HttpRequestProxy : IHttpRequestProxy
    {
        private readonly HttpClient _client;
        protected readonly HttpRequestDto Request;

        protected HttpRequestProxy(HttpClient client, HttpRequestDto request)
        {
            _client = client;
            Request = request;
        }

        public async Task<HttpResponseDto<T>> Send<T>()
        {
            using (var request = GetRequestMessage())
            {
                // Send the request and get response.
                HttpResponseMessage response = await _client.SendAsync(request).ConfigureAwait(false);

                // Read response as a string.
                var result = await response.Content.ReadAsStringAsync();

                // Deserialize the response using the classes created earlier.
                var deserializedOutput = JsonConvert.DeserializeObject<T>(result);

                return new HttpResponseDto<T>(){ RequestUri =  Request.Uri, Response = deserializedOutput};
            }
        }

        private HttpRequestMessage GetRequestMessage()
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethodRegistry.Instance[Request.Method](),
                RequestUri = new Uri(Request.Uri),
                Content = Request.Body
            };

            Request.Headers.ToList().ForEach(x => request.Headers.Add(x.Key, x.Value));

            return request;
        }
    }
}