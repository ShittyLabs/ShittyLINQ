using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T ElementAt<T>(this IEnumerable<T> self, int elementIndex)
        {
            var index = 0;
            foreach (var item in self)
            {
                if (index == elementIndex)
                {
                    return item;
                }
                index++;
            }
            return default(T);
        }
    }
}
