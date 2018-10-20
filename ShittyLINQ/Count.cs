using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static long Count<T>(this IEnumerable<T> self)
        {
            return self.Aggregate(0L, (memo, v) => ++memo);
        }

        public static long Count<T>(this IEnumerable<T> self , Func<T, bool> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();
            Func<List<T>, T, List<T>> mapFunc = (memo, obj) =>
            {
                if (predicate(obj)) memo.Add(obj);
                return memo;
            };
            var output = self.Foldl(new List<T>(), mapFunc);
            return output.Aggregate(0L, (memo, v) => ++memo);
        }
    }
}
