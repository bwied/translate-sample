namespace HttpRequestUtility
{
    public class TranslationServiceHttpRequestDto : HttpRequestDto
    {
        public string ApiVersion { get; set; }
        public string Token { get; set; }
    }
}