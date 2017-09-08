using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// This does all of the same shit as Filter except it reuses the Foldl extension method.
        /// </summary>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            Func<List<T>, T, List<T>> mapFunc = (memo, obj) =>
            {
                if (predicate(obj)) memo.Add(obj);
                return memo;
            };
            var output = self.Foldl(new List<T>(), mapFunc);
            return output;
        }
    }
}
