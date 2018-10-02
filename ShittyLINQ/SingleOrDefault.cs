using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Returns the first element of the sequence 
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
                return enumerator.Current;
            }

            return default(TSource);
        }
    }
}
