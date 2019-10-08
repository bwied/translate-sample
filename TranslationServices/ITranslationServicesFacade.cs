using System;
using System.Threading.Tasks;
using HttpRequestUtility;

namespace TranslationServices
{
    public interface ITranslationServicesFacade : IDisposable
    {
        Task<HttpResponseDto<LanguagesResult>> GetLanguagesAsync();
        Task<HttpResponseDto<LanguagesResult>> GetTranslationDictionaryAsync();
        Task<HttpResponseDto<LanguagesResult>> GetTranslationsAsync();
        Task<HttpResponseDto<LanguagesResult>> GetTransliterationsAsync();
        HttpResponseDto<TranslationResult[]> TranslateHtml(string inputText, string[] languages, string from = "");
        Task<HttpResponseDto<TranslationResult[]>> TranslateHtmlAsync(string inputText, string[] languages, string from = "");
        HttpResponseDto<TranslationResult[]> TranslateText(string inputText, string[] languages, string from = "");
        Task<HttpResponseDto<TranslationResult[]>> TranslateTextAsync(string inputText, string[] languages, string from = "");
    }
}