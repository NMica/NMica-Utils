using System.Collections.Generic;
using System.Linq;

namespace NMica.Utils
{
    internal class Vertex<T>
    {
        public Vertex()
        {
            Index = -1;
            Dependencies = new List<Vertex<T>>();
        }

        public Vertex(T value)
            : this()
        {
            Value = value;
        }

        public Vertex(IEnumerable<Vertex<T>> dependencies)
        {
            Index = -1;
            Dependencies = dependencies.ToList();
        }

        public Vertex(T value, IEnumerable<Vertex<T>> dependencies)
            : this(dependencies)
        {
            Value = value;
        }

        internal int Index { get; set; }

        internal int LowLink { get; set; }

        public T Value { get; }

        public ICollection<Vertex<T>> Dependencies { get; }
    }
}
