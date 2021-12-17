using System.Collections.Generic;

namespace NMica.Utils.Collections
{
    public static partial class DictionaryExtensions
    {
        public static TDictionary AddDictionary<TDictionary, TKey, TValue>(
            this TDictionary dictionary,
            IDictionary<TKey, TValue> otherDictionary)
            where TDictionary : IDictionary<TKey, TValue>
        {
            foreach (var (key, value) in otherDictionary)
                dictionary.AddPair(key, value);
            return dictionary;
        }

        public static TDictionary AddDictionary<TDictionary, TKey, TValue>(
            this TDictionary dictionary,
            IReadOnlyDictionary<TKey, TValue> otherDictionary)
            where TDictionary : IDictionary<TKey, TValue>
        {
            foreach (var (key, value) in otherDictionary)
                dictionary.AddPair(key, value);
            return dictionary;
        }
    }
}
