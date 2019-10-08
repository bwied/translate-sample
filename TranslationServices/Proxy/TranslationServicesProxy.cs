using System;
using System.Collections.Generic;
using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class TranslationServicesProxy : HttpRequestProxy
    {
        protected TranslationServicesProxy(HttpClient client, HttpRequestDto config = null) : base(client, config ?? new HttpRequestDto()
        {
            Host = new Uri(Config.Host).Host,
            Token = Config.Token,
            Scheme = Config.Scheme,
            ApiVersion = Config.ApiVersion,
            Headers = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(Config.TokenKey, Config.Token) },
            Parameters = new List<string>() { $"{Config.ApiVersionKey}={Config.ApiVersion}" }
        })
        {
            if (null == Config.Token)
            {
                throw new Exception("Please set/export the environment variable: " + Config.KeyVar);
            }

            if (null == Config.Host)
            {
                throw new Exception("Please set/export the environment variable: " + Config.EndpointVar);
            }
        }

    }
}