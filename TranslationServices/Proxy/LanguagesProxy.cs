using System.Net.Http;
using System.Threading.Tasks;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class LanguagesProxy : TranslationServicesProxy
    {
        public LanguagesProxy(HttpClient client, HttpRequestDto request = null) : base(client, request)
        {
            if (request != null) return;

            Request.Method = HttpMethod.Get.Method;
            Request.Route = Config.LanguageRoute;
        }

        public async Task<HttpResponseDto<LanguagesResult>> Send()
        {
            return await base.Send<LanguagesResult>();
        }
    }
}