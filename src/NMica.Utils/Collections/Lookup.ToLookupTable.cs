﻿using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace NMica.Utils.Collections
{
    [PublicAPI]
    public static class LookupExtensions
    {
        public static LookupTable<TKey, TValue> ToLookupTable<TKey, TValue>(this ILookup<TKey, TValue> lookup, IEqualityComparer<TKey> comparer)
        {
            return new LookupTable<TKey, TValue>(lookup, comparer);
        }
    }
}
