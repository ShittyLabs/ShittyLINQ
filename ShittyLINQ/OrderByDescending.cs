using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return OrderedEnumerable(source, keySelector, null, true);
        }

        public static IEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return OrderedEnumerable(source, keySelector, comparer, true);
        }

    }
}
