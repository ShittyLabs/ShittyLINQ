using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T ElementAt<T>(this IEnumerable<T> self, int elementIndex)
        {
            if (self == null) throw new ArgumentNullException();

            var index = 0;
            foreach (var item in self)
            {
                if (index == elementIndex)
                {
                    return item;
                }
                index++;
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
