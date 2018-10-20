namespace ShittyLINQ
{
    using System;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            yield return element;

            foreach (var item in source)
            {
                yield return item;
            }
        }
    }
}