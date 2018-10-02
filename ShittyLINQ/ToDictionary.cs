using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Creates a Dictionary from an IEnumerable 
        /// </summary>
        /// <param name="source">Set of elements to be converted to dictionary</param>
        /// <param name="keySelector">Key selector to determine the key of the dictionary</param>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <returns>A dictionary made from source</returns>
        /// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return ToDictionary(source, keySelector, t => t, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Creates a Dictionary from an IEnumerable 
        /// </summary>
        /// <param name="source">Set of elements to be converted to dictionary</param>
        /// <param name="keySelector">Key selector to determine the key of the dictionary</param>
        /// <param name="elementSelector">Element selector to determine the value of the dictionary</param>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TElement">Value type</typeparam>
        /// <returns>A dictionary made from source</returns>
        /// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            return source.ToDictionary(keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Creates a Dictionary from an IEnumerable 
        /// </summary>
        /// <param name="source">Set of elements to be converted to dictionary</param>
        /// <param name="keySelector">Key selector to determine the key of the dictionary</param>
        /// <param name="comparer">Comparer to be used to determine equality between elements</param>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <returns>A dictionary made from source</returns>
        /// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            return ToDictionary(source, keySelector, t => t, comparer);
        }

        /// <summary>
        /// Creates a Dictionary from an IEnumerable 
        /// </summary>
        /// <param name="source">Set of elements to be converted to dictionary</param>
        /// <param name="keySelector">Key selector to determine the key of the dictionary</param>
        /// <param name="elementSelector">Element selector to determine the value of the dictionary</param>
        /// <param name="comparer">Comparer to be used to determine equality between elements</param>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TElement">Value type</typeparam>
        /// <returns>A dictionary made from source</returns>
        /// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>( 
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> keySelector, 
            Func<TSource, TElement> elementSelector, 
            IEqualityComparer<TKey> comparer) 
        { 
            if (source == null || keySelector == null || elementSelector == null) throw new ArgumentNullException();
            
            Dictionary<TKey, TElement> ret = new Dictionary<TKey, TElement>(comparer ?? EqualityComparer<TKey>.Default); 
            foreach (TSource item in source) 
            { 
                ret.Add(keySelector(item), elementSelector(item)); 
            } 
            return ret; 
        }   
    }
    
}