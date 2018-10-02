using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Returns elements from a sequence as long as the specified condition is true.
        /// </summary>
        /// <typeparam name="TSource">The type of the source sequence.</typeparam>
        /// <param name="source">The sequence to return th elements from.</param>
        /// <param name="predicate">The predicates used to stop the function.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var element in source)
            {
                if (!predicate(element))
                    break;

                yield return element;
            }
        }

        /// <summary>
        /// Returns elements from a sequence as long as the specified condition is true. 
        /// The index of the current item is passed to the predicate function as well.
        /// </summary>
        /// <typeparam name="TSource">The type of the source sequence.</typeparam>
        /// <param name="source">The sequence to return th elements from.</param>
        /// <param name="predicate">The predicates used to stop the function.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            int i = 0;
            foreach (var element in source)
            {
                if (!predicate(element, i++))
                    break;

                yield return element;
            }
        }
    }
}
