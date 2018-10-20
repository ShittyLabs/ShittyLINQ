namespace ShittyLINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> self, IEnumerable<T> second)
        {
            return Intersect(self, second, EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> self, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            foreach (var item in self)
            {
                foreach (var secondItem in second)
                {
                    if (comparer.Equals(item, secondItem))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}