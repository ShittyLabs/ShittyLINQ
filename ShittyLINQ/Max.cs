using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static int Max<T>(this IEnumerable<T> self, Func<T, int> selector)
        {
            if (self == null || selector == null) throw new ArgumentNullException();
            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");
            var max = selector(iterator.Current);
            while(iterator.MoveNext())
            {
                var current = selector(iterator.Current);
                if (current > max) max = current;
            }
            return max;
        }
    }
}
