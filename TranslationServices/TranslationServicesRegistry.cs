using System;
using System.Collections.Generic;

namespace TranslationServices
{
    public class TranslationServicesRegistry : Registry<string, HttpApiConfigurationClient>
    {
        private static TranslationServicesRegistry _instance;

        private static readonly Dictionary<string, HttpApiConfigurationClient> Entries = new Dictionary<string, HttpApiConfigurationClient>()
        {
            {TranslationServicesStaticConfigurations.Languages.Key.Method, TranslationServicesStaticConfigurations.Languages},
            {TranslationServicesStaticConfigurations.Translations.Key.Method, TranslationServicesStaticConfigurations.Translations},
            {TranslationServicesStaticConfigurations.Transliterations.Key.Method, TranslationServicesStaticConfigurations.Transliterations},
            {TranslationServicesStaticConfigurations.TranslationDictionary.Key.Method, TranslationServicesStaticConfigurations.TranslationDictionary}
        };

        public static TranslationServicesRegistry Instance => _instance ?? (_instance = new TranslationServicesRegistry(Entries));

        public override bool HasStaticConfiguration => throw new NotImplementedException();

        public override bool IsStaticConfiguration => throw new NotImplementedException();

        public override bool HasDynamicConfiguration => throw new NotImplementedException();

        private TranslationServicesRegistry(IDictionary<string, HttpApiConfigurationClient> entries) : base(entries, null)
        {
        }

        protected override void LoadStaticConfiguration()
        {
            Load(Entries);
        }
    }
}