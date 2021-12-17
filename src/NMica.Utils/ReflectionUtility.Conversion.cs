using System.ComponentModel;
using JetBrains.Annotations;

namespace NMica.Utils
{
    public static partial class ReflectionUtility
    {
        public static T Convert<T>(string value)
        {
            return (T) Convert(value, typeof(T));
        }

        [CanBeNull]
        public static object Convert(object value, System.Type destinationType)
        {
            if (destinationType.IsInstanceOfType(value))
                return value;

            if (destinationType == typeof(string) && value == null)
                return null;

            try
            {
                var typeConverter = TypeDescriptor.GetConverter(destinationType);
                return typeConverter.ConvertFromInvariantString(value?.ToString());
            }
            catch
            {
                Assert.Fail($"Value '{value}' could not be converted to '{GetDisplayShortName(destinationType)}'");
                // ReSharper disable once HeuristicUnreachableCode
                return null;
            }
        }
    }
}
