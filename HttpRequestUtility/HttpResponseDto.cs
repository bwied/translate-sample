namespace HttpRequestUtility
{
    public class HttpResponseDto<T>
    {
        public string RequestUri { get; set; }
        public T Response { get; set; }
    }
}
