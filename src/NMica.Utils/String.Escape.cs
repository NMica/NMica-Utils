using JetBrains.Annotations;

namespace NMica.Utils
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string EscapeBraces([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.NotNull().Replace("{", "{{").Replace("}", "}}");
        }
    }
}
