using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<T> input)
        {
            if (source == null || input == null) throw new ArgumentNullException();
            List<T> target = new List<T>(source);
            target.AddRange(input);

            return target;
        }
    }
}
