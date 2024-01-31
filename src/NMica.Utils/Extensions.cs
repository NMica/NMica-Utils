using System.Collections.Generic;
using System.Threading.Tasks;

namespace NMica.Utils;

internal static class Extensions
{
    public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
    {
        if (!dictionary.TryGetValue(key, out var value))
            value = defaultValue;
        return value;
    }
}