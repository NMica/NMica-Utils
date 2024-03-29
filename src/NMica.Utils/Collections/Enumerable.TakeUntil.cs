﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NMica.Utils.Collections
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        {
            return enumerable.TakeWhile(x => !condition(x));
        }

        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        {
            return enumerable.SkipWhile(x => !condition(x));
        }
    }
}
