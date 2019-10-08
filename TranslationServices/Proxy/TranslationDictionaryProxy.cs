using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslationDictionaryProxy : LanguagesProxy
    {
        public TranslationDictionaryProxy(HttpClient client, HttpRequestDto config = null) : base(client, config)
        {
            if (config != null) return;

            Request.Parameters.Add($"{Config.ScopeKey}={Config.DictionaryScope}");
        }
    }
}