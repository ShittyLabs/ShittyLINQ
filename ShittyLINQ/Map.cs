using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Transform your shit into some other shit.
        /// </summary>
        /// <typeparam name="T">The type of shit you have.</typeparam>
        /// <typeparam name="U">The type of shit you want to have.</typeparam>
        /// <param name="self">The actual shit to transform.</param>
        /// <param name="transform">A function that converts the shit you have into the shit you want to have.</param>
        /// <returns></returns>
        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> self, Func<T, U> transform)
        {
            if (self == null || transform == null) throw new ArgumentNullException();
            var iterator = self.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return transform(iterator.Current);
            }
        }

    }
}
