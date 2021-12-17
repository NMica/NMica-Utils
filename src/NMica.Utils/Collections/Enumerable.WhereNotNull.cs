using System.Collections.Generic;
using System.Linq;

namespace NMica.Utils.Collections
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.Where(x => x != null);
        }
    }
}
