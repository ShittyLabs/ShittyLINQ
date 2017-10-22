using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> self, int count)
        {
            if (self == null) throw new ArgumentNullException();

            var index = 0;
            using (var enumerator = self.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (index >= count)
                    {
                        yield return enumerator.Current;
                    }
                    index++;
                }
            }

        }
    }
}
