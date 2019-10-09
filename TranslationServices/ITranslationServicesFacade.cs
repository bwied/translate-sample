using System;
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
        HttpResponse<TranslationResult[]> TranslateHtml(string inputText, string[] languages, string from = "");
        Task<HttpResponse<TranslationResult[]>> TranslateHtmlAsync(string inputText, string[] languages, string from = "");
        HttpResponse<TranslationResult[]> TranslateText(string inputText, string[] languages, string from = "");
        Task<HttpResponse<TranslationResult[]>> TranslateTextAsync(string inputText, string[] languages, string from = "");
    }
}