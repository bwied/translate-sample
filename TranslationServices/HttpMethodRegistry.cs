using System.Collections.Generic;
using System.Net.Http;

namespace TranslationServices
{
    public class HttpMethodRegistry : Registry<string, HttpMethod>, IRegistry<string, HttpMethod>
    {
        private static HttpMethodRegistry _instance;

        private static readonly Dictionary<string, HttpMethod> Entries = new Dictionary<string, HttpMethod>()
        {
            {"GET", HttpMethod.Get},
            {"PUT", HttpMethod.Put},
            {"POST", HttpMethod.Post},
            {"DELETE", HttpMethod.Delete},
            {"HEAD", HttpMethod.Head},
            {"OPTIONS", HttpMethod.Options},
            {"PATCH", HttpMethod.Patch},
            {"TRACE", HttpMethod.Trace}
        };

        private HttpMethodRegistry() : base(Entries, HttpMethod.Post)
        {
        }

        public static IRegistry<string, HttpMethod> Instance => _instance ?? (_instance = new HttpMethodRegistry());

        public override bool HasStaticConfiguration => true;

        public override bool IsStaticConfiguration => true;

        public override bool HasDynamicConfiguration => false;

        protected override void LoadStaticConfiguration()
        {
            Load(Entries);
        }
    }
}