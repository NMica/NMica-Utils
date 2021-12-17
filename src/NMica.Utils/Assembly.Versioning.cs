using System.Reflection;

namespace NMica.Utils
{
    public static class AssemblyExtensions
    {
        public static string GetInformationalText(this Assembly assembly)
        {
            return $"version {assembly.GetVersionText()} ({EnvironmentInfo.Platform},{EnvironmentInfo.Framework})";
        }

        public static string GetVersionText(this Assembly assembly)
        {
            var informationalVersion = assembly.GetAssemblyInformationalVersion();
            var plusIndex = informationalVersion.IndexOf(value: '+');
            return plusIndex == -1 ? "LOCAL" : informationalVersion.Substring(startIndex: 0, length: plusIndex);
        }

        private static string GetAssemblyInformationalVersion(this Assembly assembly)
        {
            return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}
