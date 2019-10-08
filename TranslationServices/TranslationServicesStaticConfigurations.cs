using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HttpRequestUtility;

namespace TranslationServices
{
    internal static class TranslationServicesStaticConfigurations
    {
        internal const string TokenKey = "Ocp-Apim-Subscription-Key";
        internal const string ApiVersionKey = "api-version";
        internal const string LanguageRoute = "languages";
        internal const string TranslateRoute = "translate";
        internal const string ScopeKey = "scope";
        internal const string TranslationScope = "translation";
        internal const string TransliterationScope = "transliteration";
        internal const string DictionaryScope = "dictionary";

        internal static readonly string Scheme = Uri.UriSchemeHttps;
        internal const string ApiVersion = "3.0";

        internal const string KeyVar = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        internal static readonly string Token = Environment.GetEnvironmentVariable(KeyVar);
        internal const string EndpointVar = "TRANSLATOR_TEXT_ENDPOINT";
        internal static readonly string Host = Environment.GetEnvironmentVariable(EndpointVar);

        internal const string To = "to";
        internal const string From = "from";
        internal const string TextType = "textType";
        internal const string HtmlTextType = "html";
    }
}