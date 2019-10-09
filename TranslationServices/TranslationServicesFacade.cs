using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HttpRequestUtility;
using TranslationServices.Proxy;

namespace TranslationServices
{
    public class TranslationServicesFacade : ITranslationServicesFacade
    {
        private readonly HttpClient _client = new HttpClient();

        public void Dispose()
        {
            _client?.Dispose();
        }

        #region Translate

        public HttpResponse<TranslationResult[]> TranslateText(string inputText, string[] languages, string from = "")
        {
            return TranslateTextAsync(inputText, languages, from).Result;
        }

        public async Task<HttpResponse<TranslationResult[]>> TranslateTextAsync(string inputText, string[] languages, string from = "")
        {
            var proxy = new TranslateProxy(_client, languages, inputText, from: from);
            var response = await proxy.Send();

            return response;
        }

        public HttpResponse<TranslationResult[]> TranslateHtml(string inputText, string[] languages, string from = "")
        {
            return TranslateHtmlAsync(inputText, languages, from).Result;
        }

        public async Task<HttpResponse<TranslationResult[]>> TranslateHtmlAsync(string inputText, string[] languages, string from = "")
        {
            var proxy = new TranslateHtmlProxy(_client, languages, inputText, from: from);
            var response = await proxy.Send();

            return response;
        }

        #endregion //Translate

        #region Languages

        public async Task<HttpResponse<LanguagesResult>> GetLanguagesAsync()
        {
            var proxy = new LanguagesProxy(_client);
            var response = await proxy.Send();

            return response;
        }

        public async Task<HttpResponse<LanguagesResult>> GetTranslationsAsync()
        {
            var proxy = new TranslationsProxy(_client);
            var response = await proxy.Send();

            return response;
        }

        public async Task<HttpResponse<LanguagesResult>> GetTransliterationsAsync()
        {
            var proxy = new TransliterationsProxy(_client);
            var response = await proxy.Send();

            return response;
        }

        public async Task<HttpResponse<LanguagesResult>> GetTranslationDictionaryAsync()
        {
            var proxy = new TranslationDictionaryProxy(_client);
            var response = await proxy.Send();

            return response;
        }

        #endregion //Languages
    }
}