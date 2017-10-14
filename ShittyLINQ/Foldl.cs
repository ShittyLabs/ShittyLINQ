using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Fold your shit to the left.
        /// </summary>
        /// <typeparam name="T">The type of shit that's 'bout to get folded.</typeparam>
        /// <typeparam name="U">The folded shit.</typeparam>
        /// <param name="self">A bunch of shit to fold.</param>
        /// <param name="seed">A seed to start your shit with. A kernel, if you will. This is optional.</param>
        /// <param name="accumulator">Describe how you want to fold this shit up.</param>
        /// <returns>The folded shit.</returns>
        public static U Foldl<T, U>(this IEnumerable<T> self, U seed, Func<U, T, U> accumulator)
        {
            var iterator = self.GetEnumerator();
            iterator.MoveNext();
            U output = accumulator(seed, iterator.Current);

            while (iterator.MoveNext())
            {
                output = accumulator(output, iterator.Current);
            }
            return output;
        }

        public static U Foldl<T, U>(this IEnumerable<T> self, Func<U, T, U> accumulator)
            where U : new()
        {
            return self.Foldl(new U(), accumulator);
        }
    }
}
