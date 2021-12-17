using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace NMica.Utils
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T obj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, obj);
            memoryStream.Seek(offset: 0, loc: SeekOrigin.Begin);
            return (T) serializer.ReadObject(memoryStream);
        }
    }
}
