using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HttpRequestUtility;

namespace TranslationServices
{
    internal static class TranslationServices
    {
        public static class ApiParameters
        {
            internal const string TokenKey = "Ocp-Apim-Subscription-Key";
            internal const string ApiVersionKey = "api-version";
            internal const string ApiVersion = "3.0";
            internal const string KeyVar = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
            internal static readonly string Token = Environment.GetEnvironmentVariable(KeyVar);
            internal const string EndpointVar = "TRANSLATOR_TEXT_ENDPOINT";
            internal static readonly string Scheme = Uri.UriSchemeHttps;
            internal static readonly string Host = Environment.GetEnvironmentVariable(EndpointVar);
            internal const string LanguageRoute = "languages";
            internal const string TranslateRoute = "translate";
            internal const string EnvironmentVariableExceptionMessage = "Please set/export the environment variable: ";
        }

        public static class LanguageParameters
        {
            internal const string LanguageRoute = ApiParameters.LanguageRoute;
            internal const string ScopeKey = "scope";
            internal const string TranslationScope = "translation";
            internal const string TransliterationScope = "transliteration";
            internal const string DictionaryScope = "dictionary";
        }

        public static class TranslateParameters
        {
            internal const string TranslateRoute = ApiParameters.TranslateRoute;
            internal const string ToKey = "to";
            internal const string FromKey = "from";
            internal const string TextTypeKey = "textType";
            internal const string TextTypeHtml = "html";
            internal const string ProfanityActionKey = "profanityAction";
            internal const string ProfanityActionMarked = "Marked";
            internal const string ProfanityActionDeleted = "Deleted";
            internal const string ProfanityMarkerKey = "profanityMarker";
            internal const string ProfanityMarkerTag = "Tag";
            internal const string IncludeSentenceLengthKey = "includeSentenceLength";
            internal const string IncludeAlignmentKey = "includeAlignment";
        }
    }
}