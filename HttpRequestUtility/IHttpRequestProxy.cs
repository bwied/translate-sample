using System;
using System.Threading.Tasks;

namespace HttpRequestUtility
{
    public interface IHttpRequestProxy
    {
        Task<HttpResponseDto<TResponse>> Send<TResponse>();
    }
}