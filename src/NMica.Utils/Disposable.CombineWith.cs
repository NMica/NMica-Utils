using System;
using JetBrains.Annotations;

namespace NMica.Utils
{
    public static class DisposableExtensions
    {
        public static IDisposable CombineWith(this IDisposable disposable, [InstantHandle] Action setup = null, [InstantHandle] Action cleanup = null)
        {
            return DelegateDisposable.CreateBracket(
                setup,
                () =>
                {
                    cleanup?.Invoke();
                    disposable.Dispose();
                });
        }

        public static IDisposable CombineWith(this IDisposable disposable, IDisposable otherDisposable)
        {
            return disposable.CombineWith(cleanup: otherDisposable.Dispose);
        }
    }
}
