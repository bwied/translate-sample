using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TranslationServices
{
    public class HttpRequest : HttpRequestMessage, IHttpRequest
    {
        private readonly HttpClient _client;

        protected HttpRequest(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> Send<T>()
        {
            // Send the request and get response.
            HttpResponseMessage response = await _client.SendAsync(this).ConfigureAwait(false);

            // Read response as a string.
            string result = await response.Content.ReadAsStringAsync();

            // Deserialize the response using the classes created earlier.
            T deserializedOutput = JsonConvert.DeserializeObject<T>(result);

            this.Dispose();

            return deserializedOutput;
        }
    }
}