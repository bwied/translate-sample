using System.Net.Http;
using System.Threading.Tasks;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServicesStaticConfigurations;

namespace TranslationServices.Proxy
{
    internal class LanguagesProxy : TranslationServicesProxy
    {
        public LanguagesProxy(HttpClient client, HttpRequestDto config = null) : base(client, config)
        {
            if (config != null) return;

            Request.Method = HttpMethod.Get.Method;
            Request.Route = Config.LanguageRoute;
        }

        public async Task<HttpResponseDto<LanguagesResult>> Send()
        {
            return await base.Send<LanguagesResult>();
        }
    }
}