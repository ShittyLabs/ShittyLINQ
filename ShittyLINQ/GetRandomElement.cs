using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> self)
        {
            Random random = new Random();
            int index = random.Next(0, (int)self.Count());
            return self.ElementAt(index);
        }
    }
}
