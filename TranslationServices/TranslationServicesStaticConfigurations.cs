using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace TranslationServices
{
    public static class TranslationServicesStaticConfigurations
    {
        private const string TokenKey = "Ocp-Apim-Subscription-Key";
        private const string ApiVersionKey = "api-version";
        private const string LanguageRoute = "languages";
        private const string TranslateRoute = "translate";
        private const string TextTypeKey = "textType";
        private const string ScopeKey = "scope";
        private const string TranslationScope = "translation";
        private const string TransliterationScope = "transliteration";
        private const string DictionaryScope = "dictionary";

        private static string Scheme => Uri.UriSchemeHttps;
        private static string ApiVersion => "3.0";

        internal const string KeyVar = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        internal const string EndpointVar = "TRANSLATOR_TEXT_ENDPOINT";
        internal static string Token { get; } = Environment.GetEnvironmentVariable(KeyVar);
        internal static string Host => Environment.GetEnvironmentVariable(EndpointVar);

        private static HttpApiConfigurationDto GetBaseConfig()
        {
            return
                new HttpApiConfigurationDto()
                {
                    Host = new Uri(Host).Host,
                    Token = Token,
                    Scheme = Scheme,
                    ApiVersion = ApiVersion,
                    Headers = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(TokenKey, Token) }
                };
        }

        private static HttpApiConfigurationDto GetBaseLanguagesConfig()
        {
            var baseConfig = GetBaseConfig();

            baseConfig.Method = HttpMethod.Get.Method;
            baseConfig.Route = $"{LanguageRoute}?{ApiVersionKey}={ApiVersion}";

            return baseConfig;
        }

        private static HttpApiConfigurationDto GetBaseTranslateConfig()
        {
            var config = GetBaseConfig();

            config.Method = HttpMethod.Post.Method;
            config.Route = $"{TranslateRoute}?{ApiVersionKey}={ApiVersion}";

            return config;
        }

        public static HttpApiConfigurationDto TranslateText
        {
            get
            {
                var config = GetBaseTranslateConfig();

                return config;
            }
        }

        public static HttpApiConfigurationDto TranslateHtml
        {
            get
            {
                var config = GetBaseTranslateConfig();

                config.Route += $"&{TextTypeKey}=html";

                return config;
            }
        }

        public static HttpApiConfigurationDto Languages => GetBaseLanguagesConfig();

        public static HttpApiConfigurationDto Translations
        {
            get
            {
                var config = GetBaseLanguagesConfig();

                config.Route = $"{config.Route}&{ScopeKey}={TranslationScope}";

                return config;
            }
        }

        public static HttpApiConfigurationDto Transliterations
        {
            get
            {
                var config = GetBaseLanguagesConfig();

                config.Route = $"{config.Route}&{ScopeKey}={TransliterationScope}";

                return config;
            }
        }

        public static HttpApiConfigurationDto TranslationDictionary
        {
            get
            {
                var config = GetBaseLanguagesConfig();

                config.Route = $"{config.Route}&{ScopeKey}={DictionaryScope}";

                return config;
            }
        }
    }
}