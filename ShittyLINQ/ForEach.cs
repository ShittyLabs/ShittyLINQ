using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Iterate over your shit any perform an action.
        /// </summary>
        /// <typeparam name="T">The type of shit.</typeparam>
        /// <param name="self">A whole bunch of your shit.</param>
        /// <param name="verb">What to do with all of this shit.</param>
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> verb)
        {
            var iterator = self.GetEnumerator();
            while (iterator.MoveNext())
            {
                verb(iterator.Current);
            }
        }
    }
}
