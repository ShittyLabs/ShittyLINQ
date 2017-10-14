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
        /// <param name="seed">A seed to start your shit with. A kernel, if you will.</param>
        /// <param name="accumulator">Describe how you want to fold this shit up.</param>
        /// <returns>The folded shit.</returns>
        public static U Foldl<T, U>(this IEnumerable<T> self, U seed, Func<U, T, U> accumulator)
        {
            var iterator = self.GetEnumerator();

            if (!iterator.MoveNext())
                return seed;

            return Foldl(iterator, accumulator(seed, iterator.Current), accumulator);
        }

        public static U Foldl<U>(this IEnumerable<U> self, Func<U, U, U> accumulator)
        {
            var iterator = self.GetEnumerator();
            iterator.MoveNext();
            return Foldl(iterator, iterator.Current, accumulator);
        }

        private static U Foldl<T, U>(IEnumerator<T> iterator, U seed, Func<U, T, U> accumulator)
        {
            U output = seed;

            while (iterator.MoveNext())
            {
                output = accumulator(output, iterator.Current);
            }
            return output;
        }
    }
}
