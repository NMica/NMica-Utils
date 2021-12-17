using System.Collections.Generic;
using JetBrains.Annotations;

namespace NMica.Utils.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> SetKeyValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            [CanBeNull] TValue value = default)
        {
            dictionary[key] = value;
            return dictionary;
        }
    }
}
