using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<U> SelectMany<T, U>(this IEnumerable<T> source, Func<T, IEnumerable<U>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            Func<List<U>, T, List<U>> iterator = (memo, val) =>
            {
                memo.AddRange(selector(val));

                return memo;
            };

            return source.Foldl(new List<U>((int)source.Count()), iterator);
        }
    }
}
