using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NMica.Utils.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}
