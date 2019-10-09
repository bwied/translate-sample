using System.Collections.Generic;
using System.Net.Http;

namespace HttpRequestUtility
{
    public class HttpRequestDto
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Route { get; set; }
        public string Method { get; set; }
        public HttpContent Body { get; set; }
        public List<string> Parameters { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
    }
}