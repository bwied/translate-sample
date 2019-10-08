using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TransliterationsProxy : LanguagesProxy
    {
        public TransliterationsProxy(HttpClient client, HttpRequestDto config = null) : base(client, config)
        {
            if (config != null) return;

            Request.Parameters.Add($"{Config.ScopeKey}={Config.TransliterationScope}");
        }
    }
}