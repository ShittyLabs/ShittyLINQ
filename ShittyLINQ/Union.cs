using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Produces the set union of two sequences.
        /// </summary>
        /// <param name="first">First set of elements</param>
        /// <param name="second">Second set of elements</param>
        /// <param name="comparer">If specified, the comparer to compare objects</param>
        /// <typeparam name="T">Type of the objects</typeparam>
        /// <returns>A set containing all the different elements in both sets</returns>
        /// <exception cref="ArgumentNullException">If first or second sets is null</exception>
        public static IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second,
            IEqualityComparer<T> comparer = null)
        {
            if (first == null || second == null) throw new ArgumentNullException();
            
            return UnionImpl(first, second, comparer ?? EqualityComparer<T>.Default);

        }

        private static IEnumerable<T> UnionImpl<T>(IEnumerable<T> first, IEnumerable<T> second,
            IEqualityComparer<T> comparer)
        {
            var seenElements = new HashSet<T>(comparer); 
            foreach (var item in first) 
            { 
                if (seenElements.Add(item)) 
                { 
                    yield return item; 
                } 
            } 
            foreach (var item in second) 
            { 
                if (seenElements.Add(item)) 
                { 
                    yield return item; 
                } 
            } 
        }
    }
}