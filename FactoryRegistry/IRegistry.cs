using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TranslationServices
{
    public interface IRegistry<TKey, TEntry>
    {
        Func<TEntry> this[TKey key] { get; }
        bool HasDefaultEntry { get; }
        bool HasStaticConfiguration { get; }
        /// <summary>
        /// Idempotent operation that will load/re-load a dynamic configuration if one exists.
        /// </summary>
        void Load(IDictionary<TKey, Func<TEntry>> entries);
        void SetDefaultEntry(Func<TEntry> defaultEntry);
    }
}