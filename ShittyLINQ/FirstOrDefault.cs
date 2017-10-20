using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> self, T defaultValue)
        {
            if (self == null) throw new ArgumentNullException();
            using (var iterator = self.GetEnumerator())
            {
                return iterator.MoveNext() ? iterator.Current : defaultValue;
            }
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> self)
        {
            return FirstOrDefault(self, default(T));
        }
    }
}
