using System;
using System.Threading.Tasks;

namespace HttpRequestUtility
{
    public interface IHttpRequestProxy
    {
        Task<HttpResponse<TResponse>> Send<TResponse>();
    }
}