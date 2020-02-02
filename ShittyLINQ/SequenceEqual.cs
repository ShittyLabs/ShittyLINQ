using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static bool SequenceEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first.Count() != second.Count())
                return false;

            var areSequenceEquals = true;

            for (int i = 0; i < first.Count(); i++)
            {
                areSequenceEquals &= (first.ElementAt(i).Equals(second.ElementAt(i)));
            }

            return areSequenceEquals;
        }

        public static bool SequenceEqual<T>(
            this IEnumerable<T> first, 
            IEnumerable<T> second,
            IEqualityComparer<T> comparer)
        {
            if (first.Count() != second.Count())
                return false;

            var areSequenceEquals = true;

            for (int i = 0; i < first.Count(); i++)
            {
                areSequenceEquals &= (comparer.Equals(first.ElementAt(i), second.ElementAt(i)));
            }

            return areSequenceEquals;
        }
    }
}
