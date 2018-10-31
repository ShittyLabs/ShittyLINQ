using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            int last = (int)self.Count() - 1;
            for(int i = last; i >=0; i--)
            {
                yield return self.ElementAt(i);
            }
        }
    }
}
