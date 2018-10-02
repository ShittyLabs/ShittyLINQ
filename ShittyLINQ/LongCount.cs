using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static long LongCount<T>(this IEnumerable<T> self)
        {
            return self.Aggregate(0L, (memo, v) => ++memo);
        }
    }
}
