using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslateHtmlProxy : TranslateProxy
    {
        public TranslateHtmlProxy(HttpClient client, string[] languages, string requestBody, string from, HttpRequestDto request = null) 
            : base(client, languages, requestBody, from, request)
        {
            if (request != null) return;

            Request.Parameters.Add($"{Config.TextTypeKey}={Config.TextTypeHtml}");
        }
    }
}