using System;
using System.Collections.Generic;
using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslationServicesProxy : HttpRequestProxy<TranslationServiceHttpRequestDto>
    {
        protected TranslationServicesProxy(HttpClient client, TranslationServiceHttpRequestDto config = null) : base(client, config ?? new TranslationServiceHttpRequestDto())
        {
            if (null == Config.Token)
            {
                throw new Exception("Please set/export the environment variable: " + Config.KeyVar);
            }

            if (null == Config.Host)
            {
                throw new Exception("Please set/export the environment variable: " + Config.EndpointVar);
            }

            Request.Host = new Uri(Config.Host).Host;
            Request.Token = Config.Token;
            Request.Scheme = Config.Scheme;
            Request.ApiVersion = Config.ApiVersion;
            Request.Headers = new List<KeyValuePair<string, string>>() {new KeyValuePair<string, string>(Config.TokenKey, Config.Token)};
            Request.Parameters = new List<string>() {$"{Config.ApiVersionKey}={Config.ApiVersion}"};
        }

    }
}