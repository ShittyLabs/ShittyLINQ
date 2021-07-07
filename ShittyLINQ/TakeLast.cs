using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> self, int count)
        {
            if (self == null) throw new ArgumentNullException();

            var numberElements = self.Count();

            if (numberElements < count) throw new ArgumentOutOfRangeException();

            var index = 0;

            foreach (T item in self)
            {
                if(index >= numberElements - count)
                {
                    yield return item;
                }
                index++;
            }
        }
    }
}
