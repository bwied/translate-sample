using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpRequestUtility;
using Newtonsoft.Json;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslateProxy : TranslationServicesProxy
    {
        public TranslateProxy(HttpClient client, string[] languages, string requestBody, HttpRequestDto config = null, string from = null) : base(client, config)
        {
            SetLanguageParameters(languages);
            SetFromParameter(from);
            SetContent(requestBody);
            Request.Method = HttpMethod.Post.Method;
            Request.Route = Config.TranslateRoute;
        }

        public async Task<HttpResponseDto<TranslationResult[]>> Send()
        {
            return await base.Send<TranslationResult[]>();
        }

        private void SetLanguageParameters(string[] languages)
        {
            Request.Parameters.AddRange(languages.Select(x => $"{Config.To}={x}"));
        }

        private void SetFromParameter(string from)
        {
            from = string.IsNullOrEmpty(from) ? "" : $"{Config.From}={from}";
            if (!string.IsNullOrEmpty(from))
            {
                Request.Parameters.Add(from);
            }
        }

        private void SetContent(string inputText)
        {
            object[] body = { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            if (!string.IsNullOrEmpty(requestBody))
            {
                Request.Body = new StringContent(requestBody, Encoding.UTF8, "application/json");
            }
        }
    }
}