using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<Tuple<T, U>> Zip<T, U>(this IEnumerable<T> source, IEnumerable<U> second)
        {
            if (source == null || second == null) throw new ArgumentNullException();

            var firstEnumerator = source.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while(firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return Tuple.Create(firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}
