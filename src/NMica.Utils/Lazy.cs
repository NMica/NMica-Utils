using System;

namespace NMica.Utils
{
    public static class Lazy
    {
        public static Lazy<T> Create<T>(Func<T> provider)
        {
            return new Lazy<T>(provider);
        }
    }
}
