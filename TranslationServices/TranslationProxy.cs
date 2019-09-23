using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TranslationServices
{
    public class TranslationProxy
    {
        private const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        private static readonly string subscriptionKey = Environment.GetEnvironmentVariable(key_var);

        private const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
        private static readonly string endpoint = Environment.GetEnvironmentVariable(endpoint_var);

        static TranslationProxy()
        {
            if (null == subscriptionKey)
            {
                throw new Exception("Please set/export the environment variable: " + key_var);
            }

            if (null == endpoint)
            {
                throw new Exception("Please set/export the environment variable: " + endpoint_var);
            }
        }

        public async Task<TranslationResult[]> TranslateTextRequest(string inputText, string[] languages, string from = "")
        {
            // This is our main function.
            // Output languages are defined in the route.
            // For a complete list of options, see API reference.
            // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
            from = string.IsNullOrEmpty(from) ? "" : $"from={from}";
            string route = string.Join('&', "translate?api-version=3.0", from, $"{string.Join('&', languages.Select(x => $"to={x}"))}");
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            return await SendRequest<TranslationResult[]>(route, HttpMethod.Post, requestBody);
        }

        public async Task<TranslationResult[]> TranslateHtmlRequest(string inputText, string[] languages)
        {
            // This is our main function.
            // Output languages are defined in the route.
            // For a complete list of options, see API reference.
            // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
            string route = $"translate?api-version=3.0&{string.Join('&', languages.Select(x => $"to={x}"))}&textType=html";
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            return await SendRequest<TranslationResult[]>(route, HttpMethod.Post, requestBody);
        }

        //public async Task<LanguagesResult> TranslationsRequest()
        //{
        //    // This is our main function.
        //    // Output languages are defined in the route.
        //    // For a complete list of options, see API reference.
        //    // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
        //    var route = $"languages?api-version=3.0&scope=translation";

        //    return await SendRequest<LanguagesResult>(route, HttpMethod.Get);
        //}

        //public async Task<Dictionary<string, Transliteration>> TransliterationsRequest()
        //{
        //    // This is our main function.
        //    // Output languages are defined in the route.
        //    // For a complete list of options, see API reference.
        //    // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
        //    var route = $"languages?api-version=3.0&scope=transliteration";

        //    return (await SendRequest<LanguagesResult>(route, HttpMethod.Get)).Transliteration;
        //}

        //public async Task<Dictionary<string, TranslationKeyValue>> TranslationDictionaryRequest()
        //{
        //    // This is our main function.
        //    // Output languages are defined in the route.
        //    // For a complete list of options, see API reference.
        //    // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
        //    var route = $"languages?api-version=3.0&scope=dictionary";

        //    return (await LanguagesRequest()).Dictionary;
        //}

        //public async Task<LanguagesResult> LanguagesRequest()
        //{
        //    // This is our main function.
        //    // Output languages are defined in the route.
        //    // For a complete list of options, see API reference.
        //    // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
        //    var route = $"languages?api-version=3.0";

        //    return await SendRequest<LanguagesResult>(route, HttpMethod.Get);
        //}

        private async Task<T> SendRequest<T>(string route, HttpMethod method, string requestBody = "")
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                // Set the method to Post.
                request.Method = method;
                // Construct the URI and add headers.
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Accept-Language", "en");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();
                // Deserialize the response using the classes created earlier.
                T deserializedOutput = JsonConvert.DeserializeObject<T>(result);
                // Iterate over the deserialized results.
                return deserializedOutput;
            }
        }
    }
}