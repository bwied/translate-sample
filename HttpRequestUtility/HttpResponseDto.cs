using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpRequestUtility
{
    public class HttpResponse<T>
    {
        private T _object;
        public HttpResponseMessage Response { get; set; }

        public T Object
        {
            get
            {
                if (_object == null)
                {
                    var result = Response.Content.ReadAsStringAsync().Result;
                    _object = JsonConvert.DeserializeObject<T>(result);
                }

                return _object;
            }
        }
    }
}
