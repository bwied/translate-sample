using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace TranslationServices
{
    public static class TranslationServicesStaticConfigurations
    {
        private const string KeyVar = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        private const string EndpointVar = "TRANSLATOR_TEXT_ENDPOINT";

        private static string Scheme => Uri.UriSchemeHttps;
        private static string Host => Environment.GetEnvironmentVariable(EndpointVar);
        private static string ApiVersion => "3.0";
        private static string Token { get; } = Environment.GetEnvironmentVariable(KeyVar);

        private static HttpApiConfigurationDto GetBaseConfig()
        {
            return
                new HttpApiConfigurationDto()
                {
                    Host = new Uri(Host).Host,
                    Token = Token,
                    Scheme = Scheme,
                    ApiVersion = ApiVersion,
                    Headers = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("Ocp-Apim-Subscription-Key", Token) }
                };
        }

        private static HttpApiConfigurationDto GetBaseLanguagesConfig()
        {
            var baseConfig = GetBaseConfig();

            baseConfig.Method = HttpMethod.Get.Method;
            baseConfig.Route = $"languages?api-version={ApiVersion}";

            return baseConfig;
        }

        public static HttpApiConfigurationClient Translate
        {
            get
            {
                var config = GetBaseConfig();

                config.Method = HttpMethod.Post.Method;
                config.Route = $"translate?api-version={ApiVersion}";

                return new HttpApiConfigurationClient(TranslationServiceAction.TranslateText, config);
            }
        }

        public static HttpApiConfigurationClient Languages => new HttpApiConfigurationClient(TranslationServiceAction.Languages, GetBaseLanguagesConfig());

        public static HttpApiConfigurationClient Translations
        {
            get
            {
                var config = GetBaseLanguagesConfig();

                config.Route = $"{config.Route}&scope=translation";

                return new HttpApiConfigurationClient(TranslationServiceAction.Translations, config);
            }
        }

        public static HttpApiConfigurationClient Transliterations
        {
            get
            {
                var config = GetBaseLanguagesConfig();

                config.Route = $"{config.Route}&scope=transliteration";

                return new HttpApiConfigurationClient(TranslationServiceAction.Transliterations, config);
            }
        }

        public static HttpApiConfigurationClient TranslationDictionary
        {
            get
            {
                var config = GetBaseLanguagesConfig();

                config.Route = $"{config.Route}&scope=dictionary";

                return new HttpApiConfigurationClient(TranslationServiceAction.TranslationDictionary, config);
            }
        }
    }
}