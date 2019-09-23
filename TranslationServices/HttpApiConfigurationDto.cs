using System.Collections.Generic;

namespace TranslationServices
{
    public class HttpApiConfigurationDto
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Route { get; set; }
        public string ApiVersion { get; set; }
        public string Token { get; set; }
        public string Method { get; set; }
        public string Query { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
    }
}