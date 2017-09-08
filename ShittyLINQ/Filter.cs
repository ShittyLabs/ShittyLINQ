using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// The filter function.
        /// </summary>
        /// <typeparam name="T">The type of shit to filter.</typeparam>
        /// <param name="self">The shit being filtered.</param>
        /// <param name="predicate">The shit you want back.</param>
        /// <returns></returns>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            var iterator = self.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (predicate(iterator.Current)) yield return iterator.Current;
            }
        }
    }
}
