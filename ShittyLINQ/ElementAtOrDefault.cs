using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T ElementAtOrDefault<T>(this IEnumerable<T> self, int elementIndex)
        {
            try {
                return ElementAt(self, elementIndex);
            }
            catch (ArgumentOutOfRangeException) {
                return default(T);
            }
        }
    }
}
