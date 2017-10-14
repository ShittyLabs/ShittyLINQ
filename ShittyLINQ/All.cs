using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// True represents that each item satisfied the given condition.
        /// </summary>
        public static bool All<T>(this IEnumerable<T> self, Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("The predicate is required.");
            }

            Func<bool, T, bool> function = (memo, obj) =>
            {
                memo &= predicate(obj);

                return memo;
            };

            return self.Foldl(true, function);
        }
    }
}
