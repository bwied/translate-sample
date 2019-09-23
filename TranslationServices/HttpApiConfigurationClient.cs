using System.Collections.Generic;

namespace TranslationServices
{
    public class HttpApiConfigurationClient : HttpApiConfigurationDto
    {
        private HttpApiConfigurationDto ConfigurationDto { get; set; }

        public HttpApiConfigurationClient(TranslationServiceAction key, HttpApiConfigurationDto configuration)
        {
            Key = key;
            ConfigurationDto = configuration;
            Scheme = configuration.Scheme;
            Host = configuration.Host;
            Route = configuration.Route;
            ApiVersion = configuration.ApiVersion;
            Token = configuration.Token;
            Method = configuration.Method;
            Query = configuration.Query;
            Headers = configuration.Headers;
        }

        public TranslationServiceAction Key { get; set; }
        //public override string Scheme => ConfigurationDto.Scheme;
        //public override string Host => ConfigurationDto.Host;
        //public override string Route => ConfigurationDto.Route;
        //public override string ApiVersion => ConfigurationDto.ApiVersion;
        //public override string Token => ConfigurationDto.Token;
        //public override string Method => ConfigurationDto.Method;
        //public override string Query => ConfigurationDto.Query;
        //public override IEnumerable<KeyValuePair<string, string>> Headers => ConfigurationDto.Headers;
    }
}