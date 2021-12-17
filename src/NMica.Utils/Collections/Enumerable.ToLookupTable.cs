using System;
using System.Collections.Generic;
using System.Linq;

namespace NMica.Utils.Collections
{
    public static partial class EnumerableExtensions
    {
        public static LookupTable<TKey, TValue> ToLookupTable<TItem, TKey, TValue>(
            this IEnumerable<TItem> enumerable,
            Func<TItem, TKey> keySelector,
            Func<TItem, TValue> valueSelector)
        {
            return new LookupTable<TKey, TValue>(enumerable.ToLookup(keySelector, valueSelector));
        }
    }
}
