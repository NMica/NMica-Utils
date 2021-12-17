using JetBrains.Annotations;

namespace NMica.Utils
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string Indent(this string text, int count)
        {
            return new string(c: ' ', count) + text;
        }
    }
}
