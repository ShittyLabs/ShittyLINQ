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
        public static U Aggregate<T, U>(this IEnumerable<T> self, U memo, Func<U, T, U> accumulator)
        {
            if (self == null) throw new ArgumentNullException();
            return self.Foldl(memo, accumulator);
        }
    }
}
