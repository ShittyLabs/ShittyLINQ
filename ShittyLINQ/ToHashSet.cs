using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Returns a <see cref="HashSet{T}"/> of the source items.
        /// </summary>
        /// <typeparam name="T">Type of elements in source sequence.</typeparam>
        /// <param name="source">Source sequence</param>
        /// <returns>A hash set of the items in the sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null</exception>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException();
            return new HashSet<T>(source);
        }
    }
}
