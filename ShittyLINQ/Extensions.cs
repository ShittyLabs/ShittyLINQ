using System;
using System.Collections.Generic;


namespace ShittyLINQ
{
    /// <summary>
    /// <para>
    /// The shitty version of LINQ.
    /// Only has some shit and some of the extension methods do the same thing but have different names.
    /// </para>
    /// <para>
    /// I strongly advise against using this shit. 
    /// It's untested and is probably super broken.
    /// This assembly wasn't supposed to leave my hard drive.
    /// </para>
    /// </summary>
    public static class Extensions
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
            var iterator = self.GetEnumerator();
            while (iterator.MoveNext())
            {
                yield return transform(iterator.Current);
            }
        }

        /// <summary>
        /// Fold your shit to the left.
        /// </summary>
        /// <typeparam name="T">The type of shit that's 'bout to get folded.</typeparam>
        /// <typeparam name="U">The folded shit.</typeparam>
        /// <param name="self">A bunch of shit to fold.</param>
        /// <param name="memo">A seed to start your shit with. A kernel, if you will.</param>
        /// <param name="accumulator">Describe how you want to fold this shit up.</param>
        /// <returns>The folded shit.</returns>
        public static U Foldl<T, U>(this IEnumerable<T> self, U memo, Func<U, T, U> accumulator)
        {
            var iterator = self.GetEnumerator();
            iterator.MoveNext();
            U output = accumulator(memo, iterator.Current);
            
            while (iterator.MoveNext())
            {
                output = accumulator(output, iterator.Current);
            }
            return output;
        }

        /// <summary>
        /// Iterate over your shit any perform an action.
        /// </summary>
        /// <typeparam name="T">The type of shit.</typeparam>
        /// <param name="self">A whole bunch of your shit.</param>
        /// <param name="verb">What to do with all of this shit.</param>
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> verb)
        {
            var iterator = self.GetEnumerator();
            while (iterator.MoveNext())
            {
                verb(iterator.Current);
            }
        }

        /// <summary>
        /// This does all of the same shit as Filter except it reuses the Foldl extension method.
        /// </summary>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            Func<List<T>, T, List<T>> mapFunc = (memo, obj) =>
            {
                if (predicate(obj)) memo.Add(obj);
                return memo;
            };
            var output = self.Foldl(new List<T>(), mapFunc);
            return output;
        }

        /// <summary>
        /// This does all the same shit as Map except it reuses the shitty version of Foldl.
        /// </summary>
        public static IEnumerable<U> Select<T, U>(this IEnumerable<T> self, Func<T, U> transform)
        {
            Func<List<U>, T, List<U>> iterator = (memo, val) => { memo.Add(transform(val)); return memo; };
            var output = self.Foldl(new List<U>(), iterator);
            return output;
        }

        /// <summary>
        /// This just passes your shit through to the Foldl extension method.
        /// </summary>
        public static U Aggregate<T, U>(this IEnumerable<T> self, U memo, Func<U, T, U> accumulator)
        {
            return self.Foldl(memo, accumulator);
        }
    }
}
