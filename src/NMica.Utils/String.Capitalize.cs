using System.Globalization;
using JetBrains.Annotations;

namespace NMica.Utils
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string Capitalize(this string text)
        {
            return !text.IsNullOrEmpty()
                ? text.Substring(startIndex: 0, length: 1).ToUpper(CultureInfo.InvariantCulture) +
                  text.Substring(startIndex: 1)
                : text;
        }
    }
}
