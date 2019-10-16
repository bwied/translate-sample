using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpRequestUtility;

namespace TranslationServices
{
    public interface ITranslationServicesFacade : IDisposable
    {
        Task<HttpResponse<LanguagesResult>> GetLanguagesAsync();
        Task<HttpResponse<LanguagesResult>> GetTranslationDictionaryAsync();
        Task<HttpResponse<LanguagesResult>> GetTranslationsAsync();
        Task<HttpResponse<LanguagesResult>> GetTransliterationsAsync();
        HttpResponse<TranslationResult[]> TranslateHtml(List<string> inputText, string[] languages, string from = "");
        Task<HttpResponse<TranslationResult[]>> TranslateHtmlAsync(List<string> inputText, string[] languages, string from = "");
        HttpResponse<TranslationResult[]> TranslateText(List<string> inputText, string[] languages, string from = "");
        Task<HttpResponse<TranslationResult[]>> TranslateTextAsync(List<string> inputText, string[] languages, string from = "");
    }
}