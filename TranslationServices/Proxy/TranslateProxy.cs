using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpRequestUtility;
using Newtonsoft.Json;
using Config = TranslationServices.Configuration.TranslateParameters;

namespace TranslationServices.Proxy
{
    internal class TranslateProxy : TranslationServicesProxy
    {
        public TranslateProxy(HttpClient client, string[] languages, List<string> requestBody, string from, HttpRequestDto request = null) : base(client, request)
        {
            SetLanguageParameters(languages);
            SetContent(requestBody);
            SetFromParameter(from);

            if (request != null) return;

            SetDefaults();
        }

        public async Task<HttpResponse<TranslationResult[]>> Send()
        {
            return await base.Send<TranslationResult[]>();
        }

        private void SetDefaults()
        {
            Request.Parameters.Add($"{Config.IncludeSentenceLengthKey}={true}");
            Request.Parameters.Add($"{Config.ProfanityActionKey}={Config.ProfanityActionMarked}");
            Request.Parameters.Add($"{Config.ProfanityMarkerKey}={Config.ProfanityMarkerTag}");
            Request.Parameters.Add($"{Config.IncludeAlignmentKey}={true}");
            Request.Method = HttpMethod.Post.Method;
            Request.Route = Config.TranslateRoute;
        }

        private void SetLanguageParameters(string[] languages)
        {
            Request.Parameters.AddRange(languages.Select(x => $"{Config.ToKey}={x}"));
        }

        private void SetFromParameter(string from)
        {
            from = string.IsNullOrEmpty(from) ? "" : $"{Config.FromKey}={from}";
            if (!string.IsNullOrEmpty(from))
            {
                Request.Parameters.Add(from);
            }
        }

        private void SetContent(List<string> inputText)
        {
            var body = new object[inputText.Count];

            for (int i = 0; i < inputText.Count; i++)
            {
                body[i] =  new { Text = inputText[i]};
            }

            //object[] body = { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            if (!string.IsNullOrEmpty(requestBody))
            {
                Request.Body = new StringContent(requestBody, Encoding.UTF8, "application/json");
            }
        }
    }
}