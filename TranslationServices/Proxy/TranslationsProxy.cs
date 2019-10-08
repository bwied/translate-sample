using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslationsProxy : LanguagesProxy
    {
        public TranslationsProxy(HttpClient client, HttpRequestDto config = null) : base(client, config)
        {
            if (config != null) return;

            Request.Parameters.Add($"{Config.ScopeKey}={Config.TranslationScope}");
        }
    }
}