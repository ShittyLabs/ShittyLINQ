using System.Collections.Generic;
using System.Collections;
using System;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Filters a sequence based on the type of the items.
        /// </summary>
        /// <typeparam name="TResult">The type to filter the items on.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            foreach(var item in source)
            {
                if (item is TResult result)
                    yield return result;
            }
        }
    }
}
