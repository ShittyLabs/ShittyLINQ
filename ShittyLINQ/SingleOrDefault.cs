using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Returns only one element of the sequence 
        /// or the default value of the type if the collection is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the items in the sequence</typeparam>
        /// <param name="source">The source sequence</param>
        /// <returns></returns>
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var first = enumerator.Current;

                if (enumerator.MoveNext())
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return first;
                }
            }

            return default(TSource);
        }

        /// <summary>
        /// Returns only one element of the sequence that meets the predicate  
        /// or the default value of the type.
        /// </summary>
        /// <typeparam name="TSource">The type of the items in the sequnce.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="predicate">The predicate on which the items are evaluated.</param>
        /// <returns></returns>
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            TSource first = default(TSource);
            bool firstIsSet = false;

            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    if (firstIsSet)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        first = enumerator.Current;
                        firstIsSet = true;
                    }
                }
            }

            return first;
        }
    }
}
