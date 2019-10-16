using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Creates a HashSet from an IEnumerable
        /// </summary>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <param name="source">Set of elements to turn into a hash set</param>
        /// <returns>A HashSet from source</returns>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source )
        {
            return ToHashSet(source, EqualityComparer<TSource>.Default);
        }

        /// <summary>
        /// Creates a HashSet from an IEnumerable and an IEqualityComparer
        /// </summary>
        /// <typeparam name="TSource">Source Type</typeparam>
        /// <param name="source">Set of elements to turn into a hash set</param>
        /// <param name="comparer"></param>
        /// <returns>A HashSet from source using comparer</returns>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            var hs = new HashSet<TSource>(comparer ?? EqualityComparer<TSource>.Default);

            foreach (TSource item in source)
            {
                hs.Add(item);
            }

            return hs;
        }
    }
}
