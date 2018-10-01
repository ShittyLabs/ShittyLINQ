using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> self, IEnumerable<T> second)
        {
            return Except(self, second, EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> self, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            if (self == null) throw new ArgumentNullException();
            if (second == null) throw new ArgumentNullException();
            foreach (var item in self)
            {
                bool contains = false;
                foreach (var secondItem in second)
                {
                    if (comparer.Equals(item, secondItem))
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains || second.Count() <= 0)
                {
                    yield return item;
                }
            }
        }
    }
}
