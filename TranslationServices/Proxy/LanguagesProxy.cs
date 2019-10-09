using System.Net.Http;
using System.Threading.Tasks;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServices.LanguageParameters;

namespace TranslationServices.Proxy
{
    internal class LanguagesProxy : TranslationServicesProxy
    {
        public LanguagesProxy(HttpClient client, TranslationServiceHttpRequestDto request = null) : base(client, request)
        {
            if (request != null) return;

            Request.Method = HttpMethod.Get.Method;
            Request.Route = Config.LanguageRoute;
        }

        public async Task<HttpResponse<LanguagesResult>> Send()
        {
            return await base.Send<LanguagesResult>();
        }
    }
}