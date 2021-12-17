using System;
using System.Security.Cryptography;
using System.Text;

namespace NMica.Utils
{
    public static partial class StringExtensions
    {
        public static string GetMD5Hash(this string str)
        {
            using var algorithm = MD5.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        public static string GetSHA256Hash(this string str)
        {
            using var algorithm = SHA256.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
