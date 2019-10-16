using System;
using System.Collections.Generic;
using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.Configuration.ApiParameters;

namespace TranslationServices.Proxy
{
    internal class TranslationServicesProxy : HttpRequestProxy<HttpRequestDto>
    {
        protected TranslationServicesProxy(HttpClient client, HttpRequestDto config = null) : base(client, config ?? new HttpRequestDto())
        {
            if (null == Config.Token) throw new Exception($"{Config.EnvironmentVariableExceptionMessage}{Config.KeyVar}");
            if (null == Config.Host) throw new Exception($"{Config.EnvironmentVariableExceptionMessage}{Config.EndpointVar}");

            Request.Host = Config.Host;
            Request.Scheme = Config.Scheme;
            Request.Headers = new List<KeyValuePair<string, string>>() {new KeyValuePair<string, string>(Config.TokenKey, Config.Token)};
            Request.Parameters = new List<string>() {$"{Config.ApiVersionKey}={Config.ApiVersion}"};
        }

    }
}