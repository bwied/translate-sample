using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslationDictionaryProxy : LanguagesProxy
    {
        public TranslationDictionaryProxy(HttpClient client, TranslationServiceHttpRequestDto request = null) : base(client, request)
        {
            if (request != null) return;

            Request.Parameters.Add($"{Config.ScopeKey}={Config.DictionaryScope}");
        }
    }
}