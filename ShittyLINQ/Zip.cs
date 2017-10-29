using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// <para>
        /// Combines two Enumerable objects into a sequence of Tuples containing each element
        /// of the source Enumerable in the first position with the element that has the same
        /// index in the second Enumerable in the second position.
        /// </para>
        /// <para>
        /// The output sequence will be as long as the shortest input sequence.
        /// </para>
        /// </summary>
        public static IEnumerable<(T, U)> Zip<T, U>(this IEnumerable<T> source, IEnumerable<U> second)
        {
            if (source == null || second == null) throw new ArgumentNullException();

            var firstEnumerator = source.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while(firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return (firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}
