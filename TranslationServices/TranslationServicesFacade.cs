using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TranslationServices
{
    public class TranslationServicesFacade : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();

        public void Dispose()
        {
            _client?.Dispose();
        }

        public TranslationResult[] TranslateText(string inputText, string[] languages, string from = "")
        {
            return TranslateTextAsync(inputText, languages, from).Result;
        }

        public async Task<TranslationResult[]> TranslateTextAsync(string inputText, string[] languages, string from = "")
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.TranslateText.Method]();
            from = string.IsNullOrEmpty(from) ? "" : $"&from={from}";
            var route = string.Join('&', settings.Route, $"{string.Join('&', languages.Select(x => $"to={x}"))}{from}");
            settings.Route = route;
            object[] body = { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            return await TranslationServicesProxy.GetInstance(_client, settings, requestBody).Send<TranslationResult[]>();
        }

        public TranslationResult[] TranslateHtml(string inputText, string[] languages, string from = "")
        {
            try
            {
                return TranslateHtmlAsync(inputText, languages, from).Result;
            }
            catch (Exception e)
            {
                return new TranslationResult[] { new TranslationResult() { Translations = new Translation[] { new Translation() { Text = inputText } } } };
            }
        }

        public async Task<TranslationResult[]> TranslateHtmlAsync(string inputText, string[] languages, string from = "")
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.TranslateHtml.Method]();
            from = string.IsNullOrEmpty(from) ? "" : $"&from={from}";
            var route = string.Join('&', settings.Route, $"{string.Join('&', languages.Select(x => $"to={x}"))}{from}");
            settings.Route = route;
            object[] body = { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            return await TranslationServicesProxy.GetInstance(_client, settings, requestBody).Send<TranslationResult[]>();
        }

        public async Task<LanguagesResult> GetLanguagesAsync()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.Languages.Method]();
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<LanguagesResult>();
        }

        public async Task<Dictionary<string, Dictionary<string, Language>>> GetTranslationsAsync()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.Translations.Method]();
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<Dictionary<string, Dictionary<string, Language>>>();
        }

        public async Task<Dictionary<string, Dictionary<string, Transliteration>>> GetTransliterationsAsync()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.Transliterations.Method]();
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<Dictionary<string, Dictionary<string, Transliteration>>>();
        }

        public async Task<Dictionary<string, Dictionary<string, TranslationKeyValue>>> GetTranslationDictionaryAsync()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.TranslationDictionary.Method]();
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<Dictionary<string, Dictionary<string, TranslationKeyValue>>>();
        }
    }
}