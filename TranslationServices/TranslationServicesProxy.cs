using System;
using System.Net.Http;

namespace TranslationServices
{
    public class TranslationServicesProxy : HttpRequest
    {
        private const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
        private static readonly string subscriptionKey = Environment.GetEnvironmentVariable(key_var);

        private const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
        private static readonly string endpoint = Environment.GetEnvironmentVariable(endpoint_var);

        public static TranslationServicesProxy GetInstance(HttpClient client, HttpApiConfigurationClient config)
        {
            if (null == subscriptionKey)
            {
                throw new Exception("Please set/export the environment variable: " + key_var);
            }

            if (null == endpoint)
            {
                throw new Exception("Please set/export the environment variable: " + endpoint_var);
            }

            return new TranslationServicesProxy(client, config);
        }

        private TranslationServicesProxy(HttpClient client, HttpApiConfigurationClient config) : base(client)
        {
            this.Method = HttpMethodRegistry.Instance[config.Method];
            foreach (var keyValuePair in config.Headers)
            {
                this.Headers.Add(keyValuePair.Key, keyValuePair.Value);
            }
            this.RequestUri = new Uri(endpoint + config.Route);
        }
    }
}