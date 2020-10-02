using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Repeats the element n times.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="element">The element that needs to be repeated.</param>
        /// <param name="count">The number of times to repeat the element. Must be a non-negative number.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            for (int i = 0; i < count; i++)
            {
                yield return element;
            }
        }
    }
}
