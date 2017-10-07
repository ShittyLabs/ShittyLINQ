using System.Collections.Generic;
using System.Linq;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static bool Contains<T>(this IEnumerable<T> self, IEnumerable<T> items)
        {
            return items.All(item => self.Contains(item));
        }
    }
}
