using System.Xml.Linq;

namespace NMica.Utils
{
    public static partial class XElementExtensions
    {
        public static string GetAttributeValue(this XElement element, string name)
        {
            return element.Attribute(name).NotNull().Value;
        }
    }
}
