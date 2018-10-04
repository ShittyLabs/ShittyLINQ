using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
	public static partial class Extensions
	{
		/// <summary>
		/// Creates a lookup from an IEnumerable 
		/// </summary>
		/// <param name="source">Set of elements to be converted to lookup</param>
		/// <param name="keySelector">Key selector to determine the key of the lookup</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <returns>A lookup made from source</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TSource>> ToLookup<TSource, TKey>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector)
		{
			return ToLookup(source, keySelector, t => t, EqualityComparer<TKey>.Default);
		}

		/// <summary>
		/// Creates a lookup from an IEnumerable 
		/// </summary>
		/// <param name="source">Set of elements to be converted to lookup</param>
		/// <param name="keySelector">Key selector to determine the key of the lookup</param>
		/// <param name="elementSelector">Element selector to determine the value of the lookup</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <typeparam name="TElement">Value type</typeparam>
		/// <returns>A lookup made from source</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TElement>> ToLookup<TSource, TKey, TElement>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector)
		{
			return source.ToLookup(keySelector, elementSelector, EqualityComparer<TKey>.Default);
		}

		/// <summary>
		/// Creates a lookup from an IEnumerable 
		/// </summary>
		/// <param name="source">Set of elements to be converted to lookup</param>
		/// <param name="keySelector">Key selector to determine the key of the lookup</param>
		/// <param name="comparer">Comparer to be used to determine equality between elements</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <returns>A lookup made from source</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TSource>> ToLookup<TSource, TKey>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			IEqualityComparer<TKey> comparer)
		{
			return ToLookup(source, keySelector, t => t, comparer);
		}

		/// <summary>
		/// Creates a lookup from an IEnumerable 
		/// </summary>
		/// <param name="source">Set of elements to be converted to lookup</param>
		/// <param name="keySelector">Key selector to determine the key of the lookup</param>
		/// <param name="elementSelector">Element selector to determine the value of the lookup</param>
		/// <param name="comparer">Comparer to be used to determine equality between elements</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <typeparam name="TElement">Value type</typeparam>
		/// <returns>A lookup made from source</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TElement>> ToLookup<TSource, TKey, TElement>(
			this IEnumerable<TSource> source,
			Func<TSource, TKey> keySelector,
			Func<TSource, TElement> elementSelector,
			IEqualityComparer<TKey> comparer)
		{
			if (source == null || keySelector == null || elementSelector == null) throw new ArgumentNullException();

			List<TElement> tempList;
			IEnumerable<TElement> existingValues;

			Dictionary<TKey, IEnumerable<TElement>> ret = new Dictionary<TKey, IEnumerable<TElement>>(comparer ?? EqualityComparer<TKey>.Default);
			foreach (TSource item in source)
			{
				existingValues  = ret.GetValueOrDefault(keySelector(item));
				if (existingValues == null)
				{
					tempList = new List<TElement>();
				}
				else
				{
					tempList = existingValues.ToList();
					ret.Remove(keySelector(item));
				}
				tempList.Add(elementSelector(item));
				ret.Add(keySelector(item), tempList);

			}
			return ret;
		}
	}

}