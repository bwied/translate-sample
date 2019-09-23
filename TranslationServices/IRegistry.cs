using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TranslationServices
{
    public interface IRegistry<TKey, TEntry>
    {
        TEntry this[TKey key] { get; }
        bool HasDefaultEntry { get; }
        bool HasStaticConfiguration { get; }
        bool HasDynamicConfiguration { get; }
        bool IsStaticConfiguration { get; }
        /// <summary>
        /// Idempotent operation that will load/re-load a dynamic configuration if one exists.
        /// </summary>
        void Load(IDictionary<TKey, TEntry> entries);
        void SetDefaultEntry(TEntry defaultEntry);
    }
}