using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace NMica.Utils
{
    public static partial class StringExtensions
    {
        [Pure]
        public static int IndexOfRegex(this string text, string expression)
        {
            var regex = new Regex(expression, RegexOptions.Compiled);
            return regex.Match(text).Index;
        }
    }
}
