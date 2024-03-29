﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace NMica.Utils.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AddPair<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            [CanBeNull] TValue value = default)
        {
            dictionary.Add(key, value);
            return dictionary;
        }

        public static IDictionary<TKey, TValue> AddPairWhenKeyNotNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            [CanBeNull] TKey key,
            [CanBeNull] TValue value = default)
            where TKey : class
        {
            return key != null
                ? dictionary.AddPair(key, value)
                : dictionary;
        }

        public static IDictionary<TKey, TValue> AddPairWhenValueNotNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            [CanBeNull] TKey key,
            [CanBeNull] TValue value)
            where TValue : class
        {
            return value != null
                ? dictionary.AddPair(key, value)
                : dictionary;
        }
    }
}
