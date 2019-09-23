namespace TranslationServices
{
    public class TranslationServiceAction : ServiceAction
    {
        public static TranslationServiceAction TranslateText => new TranslationServiceAction() { Method = "TranslateText" };
        public static TranslationServiceAction Languages => new TranslationServiceAction() { Method = "Languages" };
        public static TranslationServiceAction Translations => new TranslationServiceAction() { Method = "Translations" };
        public static TranslationServiceAction Transliterations => new TranslationServiceAction() { Method = "Transliterations" };
        public static TranslationServiceAction TranslationDictionary => new TranslationServiceAction() { Method = "TranslationDictionary" };
    }
}