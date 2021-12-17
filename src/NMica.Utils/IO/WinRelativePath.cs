using System;
using JetBrains.Annotations;
using static NMica.Utils.IO.PathConstruction;

namespace NMica.Utils.IO
{
    [PublicAPI]
    [Serializable]
    public class WinRelativePath : RelativePath
    {
        protected WinRelativePath(string path, char? separator)
            : base(path, separator)
        {
        }

        public static explicit operator WinRelativePath([CanBeNull] string path)
        {
            return new WinRelativePath(NormalizePath(path, WinSeparator), WinSeparator);
        }
    }
}
