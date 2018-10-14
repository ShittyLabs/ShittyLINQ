using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            if (outer == null || outerKeySelector == null || innerKeySelector == null || resultSelector == null) throw new ArgumentNullException();
            var outerIterator = outer.GetEnumerator();

            var comparer = EqualityComparer<TKey>.Default;
            TOuter currentOuter = outerIterator.Current;

            while (outerIterator.MoveNext())
            {
                currentOuter = outerIterator.Current;
                TInner currentInner;
                var innerIterator = inner.GetEnumerator();

                // Find match from inner
                while (innerIterator.MoveNext())
                {
                    currentInner = innerIterator.Current;
                    if (comparer.Equals(outerKeySelector(currentOuter), innerKeySelector(currentInner)))
                    {
                        yield return resultSelector(currentOuter, currentInner);
                    }
                }
            }
        }
    }
}
