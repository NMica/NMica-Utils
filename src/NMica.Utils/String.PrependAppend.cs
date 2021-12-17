using JetBrains.Annotations;

namespace NMica.Utils
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string Prepend(this string str, string prependText)
        {
            return prependText + str;
        }

        [Pure]
        public static string Append(this string str, string appendText)
        {
            return str + appendText;
        }
    }
}
