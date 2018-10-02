using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException();

            if (predicate != null)
            {
                source = source.Where(predicate);
            }

            var count = source.Count();
            if (count == 0)
            {
                throw new InvalidOperationException("No elements in sequence");
            }
            else if (count > 1)
            {
                throw new InvalidOperationException("More than one element satifies predicate");
            }

            return source.ElementAt(0);
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source)
            => Single(source, null);
    }
}
