using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TranslationServices
{
    public class Class1
    {
    }
    /// <summary>
    /// The C# classes that represents the JSON returned by the Translator Text API.
    /// </summary>
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }
        public TextResult SourceText { get; set; }
        public Translation[] Translations { get; set; }
    }

    public class DetectedLanguage
    {
        public string Language { get; set; }
        public float Score { get; set; }
    }

    public class TextResult
    {
        public string Text { get; set; }
        public string Script { get; set; }
    }

    public class Translation
    {
        public string Text { get; set; }
        public TextResult Transliteration { get; set; }
        public string To { get; set; }
        public Alignment Alignment { get; set; }
        public SentenceLength SentLen { get; set; }
    }

    public class Alignment
    {
        public string Proj { get; set; }
    }

    public class SentenceLength
    {
        public int[] SrcSentLen { get; set; }
        public int[] TransSentLen { get; set; }
    }

    public class LanguagesResult
    {
        public Dictionary<string, Language> Translation { get; set; }
        public Dictionary<string, Transliteration> Transliteration { get; set; }
        public Dictionary<string, TranslationKeyValue> Dictionary { get; set; }
    }

    public class TranslationBase
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
    }

    public class Language : TranslationBase
    {
        public string Dir { get; set; }
    }

    public class Transliteration : TranslationBase
    {
        public List<Scripts> Scripts { get; set; }
    }

    public class Script : Language
    {
        public string Code { get; set; }
    }

    public class Scripts : Script
    {
        public List<Script> ToScripts { get; set; }
    }

    public class TranslationKeyValue : Language
    {
        public List<Script> Translations { get; set; }
    }
}
