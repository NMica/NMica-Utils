using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NMica.Utils.Collections
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this object obj)
        {
            return obj is IEnumerable enumerable ? enumerable.Cast<T>() : new[] { (T) obj };
        }
    }
}
