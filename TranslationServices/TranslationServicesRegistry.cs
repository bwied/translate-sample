using System;
using System.Collections.Generic;
using FactoryRegistry;

namespace TranslationServices
{
    public class TranslationServicesRegistry : Registry<string, HttpApiConfigurationDto>
    {
        private static TranslationServicesRegistry _instance;

        private static readonly Dictionary<string, Func<HttpApiConfigurationDto>> Entries = new Dictionary<string, Func<HttpApiConfigurationDto>>()
        {
            {TranslationServiceAction.TranslateText.Method, () => TranslationServicesStaticConfigurations.TranslateText},
            {TranslationServiceAction.TranslateHtml.Method, () => TranslationServicesStaticConfigurations.TranslateHtml},
            {TranslationServiceAction.Languages.Method, () => TranslationServicesStaticConfigurations.Languages},
            {TranslationServiceAction.Translations.Method, () => TranslationServicesStaticConfigurations.Translations},
            {TranslationServiceAction.Transliterations.Method, () => TranslationServicesStaticConfigurations.Transliterations},
            {TranslationServiceAction.TranslationDictionary.Method, () => TranslationServicesStaticConfigurations.TranslationDictionary}
        };

        public static TranslationServicesRegistry Instance => _instance ?? (_instance = new TranslationServicesRegistry(Entries));

        public override bool HasStaticConfiguration => true;

        private TranslationServicesRegistry(IDictionary<string, Func<HttpApiConfigurationDto>> entries) : base(entries, null)
        {
        }

        protected override void LoadStaticConfiguration()
        {
            Load(Entries);
        }
    }
}