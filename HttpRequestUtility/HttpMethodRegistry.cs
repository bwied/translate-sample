using System;
using System.Collections.Generic;
using System.Net.Http;
using FactoryRegistry;
using TranslationServices;

namespace HttpRequestUtility
{
    public class HttpMethodRegistry : RegistryDictionary<string, HttpMethod>
    {
        private static HttpMethodRegistry _instance;

        private static readonly Dictionary<string, Func<HttpMethod>> Entries = new Dictionary<string, Func<HttpMethod>>()
        {
            {"GET", () => HttpMethod.Get},
            {"PUT", () => HttpMethod.Put},
            {"POST", () => HttpMethod.Post},
            {"DELETE", () => HttpMethod.Delete},
            {"HEAD", () => HttpMethod.Head},
            {"OPTIONS", () => HttpMethod.Options},
            {"PATCH", () => HttpMethod.Patch},
            {"TRACE", () => HttpMethod.Trace}
        };

        private HttpMethodRegistry() : base(Entries, () => HttpMethod.Post)
        {
        }

        public static IRegistry<string, HttpMethod> Instance => _instance ?? (_instance = new HttpMethodRegistry());

        public override bool HasStaticConfiguration => true;

        protected override void LoadStaticConfiguration()
        {
            Load(Entries);
        }
    }
}