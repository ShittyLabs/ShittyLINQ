using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T Last<T>(this IEnumerable<T> self)
        {
            if (self == null) throw new ArgumentNullException();
            using (var iterator = self.GetEnumerator())
            {
                if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");
                var result = iterator.Current;
                while (iterator.MoveNext())
                {
                    result = iterator.Current;
                }
                return result;
            }
        }
    }
}
