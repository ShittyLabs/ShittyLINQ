using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> self)
        {
            if (self == null) throw new ArgumentNullException();
            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) return default(T);
            return iterator.Current;
        }
    }
}
