using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// This does all the same shit as Map except it reuses the shitty version of Foldl.
        /// </summary>
        public static IEnumerable<U> Select<T, U>(this IEnumerable<T> self, Func<T, U> transform)
        {
            Func<List<U>, T, List<U>> iterator = (memo, val) => { memo.Add(transform(val)); return memo; };
            var output = self.Foldl(new List<U>(), iterator);
            return output;
        }
    }
}
