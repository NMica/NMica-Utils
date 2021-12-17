#if NETFRAMEWORK
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace NMica.Utils.Collections
{
    [PublicAPI]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public static partial class DictionaryExtensions
    {
        [CanBeNull]
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue = default)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
}
#endif
