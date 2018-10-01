using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static bool Contains<T>(this IEnumerable<T> self, T element)
        {
            if (self == null || element == null) throw new ArgumentNullException();
            foreach (var item in self)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
    }
}