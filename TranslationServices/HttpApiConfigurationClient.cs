using System.Collections.Generic;

namespace TranslationServices
{
    public class HttpApiConfigurationClient
    {
        private HttpApiConfigurationDto ConfigurationDto { get; set; }

        public HttpApiConfigurationClient(TranslationServiceAction key, HttpApiConfigurationDto configuration)
        {
            Key = key;
            ConfigurationDto = configuration;
        }

        public TranslationServiceAction Key { get; set; }
        public string Scheme => ConfigurationDto.Scheme;
        public string Host => ConfigurationDto.Host;
        public string Route => ConfigurationDto.Route;
        public string ApiVersion => ConfigurationDto.ApiVersion;
        public string Token => ConfigurationDto.Token;
        public string Method => ConfigurationDto.Method;
        public string Query => ConfigurationDto.Query;
        public IEnumerable<KeyValuePair<string, string>> Headers => ConfigurationDto.Headers;

    }
}