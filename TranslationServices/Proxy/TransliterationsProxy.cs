using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.Configuration.LanguageParameters;

namespace TranslationServices.Proxy
{
    internal class TransliterationsProxy : LanguagesProxy
    {
        public TransliterationsProxy(HttpClient client, HttpRequestDto request = null) : base(client, request)
        {
            if (request != null) return;

            Request.Parameters.Add($"{Config.ScopeKey}={Config.TransliterationScope}");
        }
    }
}