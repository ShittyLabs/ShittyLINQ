using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException();
            Func<List<T>, T, List<T>> toList = (memo, value) => { memo.Add(value); return memo; };
            return source.Foldl(new List<T>(), toList);
        }
    }
}
