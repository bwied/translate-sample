using System;
using System.Net.Http;
using System.Text;

namespace TranslationServices
{
    public class TranslationServicesProxy : HttpRequest
    {
        public static TranslationServicesProxy GetInstance(HttpClient client, HttpApiConfigurationDto config, string requestBody = null)
        {
            if (null == TranslationServicesStaticConfigurations.Token)
            {
                throw new Exception("Please set/export the environment variable: " + TranslationServicesStaticConfigurations.KeyVar);
            }

            if (null == TranslationServicesStaticConfigurations.Host)
            {
                throw new Exception("Please set/export the environment variable: " + TranslationServicesStaticConfigurations.EndpointVar);
            }

            return new TranslationServicesProxy(client, config, requestBody);
        }

        private TranslationServicesProxy(HttpClient client, HttpApiConfigurationDto config, string requestBody) : base(client)
        {
            this.Method = HttpMethodRegistry.Instance[config.Method]();
            foreach (var keyValuePair in config.Headers)
            {
                this.Headers.Add(keyValuePair.Key, keyValuePair.Value);
            }
            this.RequestUri = new Uri(TranslationServicesStaticConfigurations.Host + config.Route);

            if (!string.IsNullOrEmpty(requestBody))
            {
                this.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            }
        }
    }
}