using System;
using NMica.Utils.IO;

namespace NMica.Utils
{
    public static partial class EnvironmentInfo
    {
        public static string NewLine => Environment.NewLine;
        public static string MachineName => Environment.MachineName;

        public static AbsolutePath WorkingDirectory
        {
#if NETCORE
            get => (AbsolutePath) Directory.GetCurrentDirectory();
            set => Directory.SetCurrentDirectory(value);
#else
            get => (AbsolutePath) Environment.CurrentDirectory;
            set => Environment.CurrentDirectory = value;
#endif
        }
    }
}
