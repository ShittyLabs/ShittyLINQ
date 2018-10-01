using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> source)
        {
            return DefaultIfEmpty(source, default(T));
        }

        public static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> self, T defaultValue)
        {
            if (self == null) throw new ArgumentNullException();
            if (self.Count() <= 0)
            {
                yield return defaultValue;
            }
            else
            {
                var iterator = self.GetEnumerator();
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }
    }
}
