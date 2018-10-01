using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static bool Contains<T>(this IEnumerable<T> self, T element)
        {
            var enumerator = self.GetEnumerator();
            while(enumerator.MoveNext())
            {
                if (EqualityComparer<T>.Default.Equals(enumerator.Current, element)) return true;
            }
            return false;
        }

        public static bool Contains<T>(this IEnumerable<T> self, T element, IEqualityComparer<T> equalityComparer)
        {
            var enumerator = self.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (equalityComparer.Equals(enumerator.Current, element)) return true;
            }
            return false;
        }

    }
}
