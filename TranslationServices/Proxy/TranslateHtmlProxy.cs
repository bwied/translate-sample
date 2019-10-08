using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslateHtmlProxy : TranslateProxy
    {
        public TranslateHtmlProxy(HttpClient client, string[] languages, string requestBody, HttpRequestDto request = null, string from = null) 
            : base(client, languages, requestBody, request, from)
        {
            Request.Parameters.Add($"{Config.TextType}={Config.HtmlTextType}");
        }
    }
}