﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace NMica.Utils.Collections
{
    public static partial class EnumerableExtensions
    {
        [CanBeNull]
        public static T SingleOrDefaultOrError<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, string message)
        {
            try
            {
                return enumerable.SingleOrDefault(predicate);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }

        [CanBeNull]
        public static T SingleOrDefaultOrError<T>(this IEnumerable<T> enumerable, string message)
        {
            try
            {
                return enumerable.SingleOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }

        [CanBeNull]
        public static T SingleOrError<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, string message)
        {
            try
            {
                return enumerable.Single(predicate);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }

        [CanBeNull]
        public static T SingleOrError<T>(this IEnumerable<T> enumerable, string message)
        {
            try
            {
                return enumerable.Single();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }
    }
}
