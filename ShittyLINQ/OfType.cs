using System;
using System.Collections;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable self)
        {
            if (self == null) throw new ArgumentNullException();
            return OfTypeIterator<TResult>(self);
        }

        private static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source)
        {
            foreach (object obj in source)
            {
                if (obj is TResult) yield return (TResult)obj;
            }
        }
    }
}
