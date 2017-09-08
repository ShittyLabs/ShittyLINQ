using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T First<T>(this IEnumerable<T> self)
        {
            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new Exception("The set is empty.");
            return iterator.Current;
        }
    }
}
