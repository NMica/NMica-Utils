using System;
using JetBrains.Annotations;

namespace NMica.Utils
{
    public class DelegateDisposable : IDisposable
    {
        public static IDisposable CreateBracket([InstantHandle] Action setup = null, [InstantHandle] Action cleanup = null)
        {
            setup?.Invoke();
            return new DelegateDisposable(cleanup);
        }

        [CanBeNull] private readonly Action _cleanup;

        private DelegateDisposable([CanBeNull] Action cleanup)
        {
            _cleanup = cleanup;
        }

        public void Dispose()
        {
            _cleanup?.Invoke();
        }
    }
}
