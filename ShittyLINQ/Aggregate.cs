using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// This just passes your shit through to the Foldl extension method.
        /// </summary>
        public static U Aggregate<T, U>(this IEnumerable<T> self, U seed, Func<U, T, U> accumulator)
        {
            return self.Foldl(seed, accumulator);
        }

        public static U Aggregate<T, U>(this IEnumerable<T> self, Func<U, T, U> accumulator)
            where U : new()
        {
            return self.Foldl(seed, new U(), accumulator);
        }
    }
}
