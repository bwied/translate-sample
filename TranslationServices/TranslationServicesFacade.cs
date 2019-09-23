using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TranslationServices
{
    public class TranslationServicesFacade : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<LanguagesResult> GetLanguages()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.Languages.Method];
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<LanguagesResult>();
        }

        public async Task<Dictionary<string, Dictionary<string, Language>>> GetTranslations()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.Translations.Method];
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<Dictionary<string, Dictionary<string, Language>>>();
        }

        public async Task<Dictionary<string, Dictionary<string, Transliteration>>> GetTransliterations()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.Transliterations.Method];
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<Dictionary<string, Dictionary<string, Transliteration>>>();
        }

        public async Task<Dictionary<string, Dictionary<string, TranslationKeyValue>>> GetTranslationDictionary()
        {
            var settings = TranslationServicesRegistry.Instance[TranslationServiceAction.TranslationDictionary.Method];
            return await TranslationServicesProxy.GetInstance(_client, settings).Send<Dictionary<string, Dictionary<string, TranslationKeyValue>>>();
        }
    }
}