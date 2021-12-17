using System;
using JetBrains.Annotations;
using static NMica.Utils.IO.PathConstruction;

namespace NMica.Utils.IO
{
    [PublicAPI]
    [Serializable]
    public class UnixRelativePath : RelativePath
    {
        protected UnixRelativePath(string path, char? separator)
            : base(path, separator)
        {
        }

        public static explicit operator UnixRelativePath([CanBeNull] string path)
        {
            return new UnixRelativePath(NormalizePath(path, UnixSeparator), UnixSeparator);
        }
    }
}
