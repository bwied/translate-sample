using System.Collections.Generic;
using System.Net.Http;

namespace HttpRequestUtility
{
    public class HttpRequestDto
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Route { get; set; }
        public string ApiVersion { get; set; }
        public string Token { get; set; }
        public string Method { get; set; }
        public StringContent Body { get; set; }
        public List<string> Parameters { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }

        public string Uri
        {
            get
            {
                var test = $"{Scheme}://{Host}/{string.Join('?', Route, Query)}";
                return test;
            }
        }

        public string Query
        {
            get { return string.Join('&', Parameters); }
        }
    }
}