using System;
using System.Reflection;

namespace NMica.Utils
{
    public static class ExceptionExtensions
    {
        public static Exception Unwrap(this Exception exception)
        {
            return exception switch
            {
                TypeInitializationException typeInitializationException => typeInitializationException.InnerException.Unwrap(),
                TargetInvocationException targetInvocationException => targetInvocationException.InnerException.Unwrap(),
                AggregateException aggregateException => aggregateException.Flatten(),
                _ => exception
            };
        }
    }
}
