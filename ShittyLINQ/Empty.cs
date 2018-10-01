using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// The empty function.
        /// </summary>
        /// <typeparam name="T">The type of shit to return.</typeparam>
        /// <param name="self">The shit being initialized.</param>
        /// <returns></returns>
        public static IEnumerable<T> Empty<T> (this IEnumerable<T> self) => new List<T> ();
    }
}
