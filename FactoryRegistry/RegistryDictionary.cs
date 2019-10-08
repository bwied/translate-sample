using System;
using System.Collections.Generic;
using TranslationServices;

namespace FactoryRegistry
{
    /// <summary>
    /// Provides a generic interface to encapsulate domain logic execution via a dictionary of functions.
    /// </summary>
    /// <typeparam name="TKey">Domain specific definition</typeparam>
    /// <typeparam name="TEntry">Executable function wrapper for domain specific logic.</typeparam>
    public abstract class RegistryDictionary<TKey, TEntry> : Dictionary<TKey, Func<TEntry>>, IRegistry<TKey, TEntry>
    {
        private Func<TEntry> _defaultEntry;

        protected RegistryDictionary(IDictionary<TKey, Func<TEntry>> entries, Func<TEntry> defaultEntry) : base(entries)
        {
            _defaultEntry = defaultEntry;
        }

        private Func<TEntry> DefaultEntry
        {
            get
            {
                if (_defaultEntry == null)
                {
                    throw new Exception("No such entry exists in this registry and no default entry has been configured.");
                }
                return _defaultEntry;
            }
        }

        public new virtual Func<TEntry> this[TKey key] => this.ContainsKey(key) ? base[key] : DefaultEntry;

        public bool HasDefaultEntry => _defaultEntry != null;

        public abstract bool HasStaticConfiguration { get; }

        protected abstract void LoadStaticConfiguration();

        public virtual void Load(IDictionary<TKey, Func<TEntry>> entries = null)
        {
            if (entries == null && HasStaticConfiguration)
            {
                LoadStaticConfiguration();
            }
            else if (entries != null)
            {
                base.Clear();
                foreach (var (key, value) in entries)
                {
                    base.Add(key, value);
                }
            }
        }

        public virtual void SetDefaultEntry(Func<TEntry> defaultEntry)
        {
            if (defaultEntry != null && !this.ContainsValue(defaultEntry))
            {
                var ex = new Exception("No such entry exists in this registry. You must add this entry prior to setting it as the default.");
                ex.Data.Add(defaultEntry, defaultEntry);
            }
            _defaultEntry = defaultEntry;
        }
    }
}