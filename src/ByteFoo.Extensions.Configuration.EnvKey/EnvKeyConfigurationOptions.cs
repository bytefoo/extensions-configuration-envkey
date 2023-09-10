using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteFoo.Extensions.Configuration.EnvKey
{
    public class EnvKeyConfigurationOptions
    {
        private readonly List<Func<string, ValueTask<string>>>
            _keyMappers = new List<Func<string, ValueTask<string>>>();

        private readonly SortedSet<string> _keyPrefixes =
            new SortedSet<string>(Comparer<string>.Create((k1, k2) =>
                -string.Compare(k1, k2, StringComparison.OrdinalIgnoreCase)));

        private readonly List<KeyValueSelector> _kvSelectors = new List<KeyValueSelector>();

        private readonly List<Func<string, ValueTask<string>>> _valueMappers =
            new List<Func<string, ValueTask<string>>>();

        public string EnvKey { get; private set; }

        public string EnvKeyPath { get; private set; }

        internal IEnumerable<Func<string, ValueTask<string>>> KeyMappers => _keyMappers;

        internal IEnumerable<string> KeyPrefixes => _keyPrefixes;

        public IEnumerable<KeyValueSelector> KeyValueSelectors => _kvSelectors;

        public bool UseCache { get; set; }

        internal IEnumerable<Func<string, ValueTask<string>>> ValueMappers => _valueMappers;

        public EnvKeyConfigurationOptions Connect(string envKey)
        {
            if (string.IsNullOrWhiteSpace(envKey))
            {
                throw new ArgumentNullException(nameof(envKey));
            }

            EnvKey = envKey;
            return this;
        }

        public EnvKeyConfigurationOptions Path(string envKeyPath)
        {
            if (string.IsNullOrWhiteSpace(envKeyPath))
            {
                throw new ArgumentNullException(nameof(envKeyPath));
            }

            EnvKeyPath = envKeyPath;
            return this;
        }

        public EnvKeyConfigurationOptions Cache(bool useCache = false)
        {
            UseCache = useCache;
            return this;
        }

        public EnvKeyConfigurationOptions Select(string keyFilter)
        {
            if (string.IsNullOrEmpty(keyFilter))
            {
                throw new ArgumentNullException(nameof(keyFilter));
            }

            if (!_kvSelectors.Any(s => s.KeyFilter.Equals(keyFilter)))
            {
                _kvSelectors.Add(new KeyValueSelector
                {
                    KeyFilter = keyFilter
                });
            }

            return this;
        }

        public EnvKeyConfigurationOptions TrimKeyPrefix(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentNullException(nameof(prefix));
            }

            _keyPrefixes.Add(prefix);
            return this;
        }

        public EnvKeyConfigurationOptions MapKeys(Func<string, ValueTask<string>> mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _keyMappers.Add(mapper);
            return this;
        }

        public EnvKeyConfigurationOptions MapValues(Func<string, ValueTask<string>> mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            _valueMappers.Add(mapper);
            return this;
        }
    }
}