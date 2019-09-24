using System.Collections.Generic;

namespace TranslationServices
{
    public class LanguagesResult
    {
        public Dictionary<string, Language> Translation { get; set; }
        public Dictionary<string, Transliteration> Transliteration { get; set; }
        public Dictionary<string, TranslationKeyValue> Dictionary { get; set; }
    }
}
