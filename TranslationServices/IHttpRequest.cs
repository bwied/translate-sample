using System;
using System.Threading.Tasks;

namespace TranslationServices
{
    public interface IHttpRequest : IDisposable
    {
        Task<T> Send<T>();
    }
}