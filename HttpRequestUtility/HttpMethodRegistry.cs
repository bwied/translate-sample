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
            {HttpMethod.Get.Method, () => HttpMethod.Get},
            {HttpMethod.Put.Method, () => HttpMethod.Put},
            {HttpMethod.Post.Method, () => HttpMethod.Post},
            {HttpMethod.Delete.Method, () => HttpMethod.Delete},
            {HttpMethod.Head.Method, () => HttpMethod.Head},
            {HttpMethod.Options.Method, () => HttpMethod.Options},
            {HttpMethod.Patch.Method, () => HttpMethod.Patch},
            {HttpMethod.Trace.Method, () => HttpMethod.Trace}
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