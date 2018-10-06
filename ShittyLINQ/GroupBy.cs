using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
	public static partial class Extensions
	{
		/// <summary>
		/// Groups the elements of a sequence.
		/// </summary>
		/// <param name="source">An IEnumerable<T> whose elements to group.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <returns> A collection of elements where each element represents a projection over a group and its key.</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TSource>> GroupBy<TSource, TKey>(
					this IEnumerable<TSource> source,
					Func<TSource, TKey> keySelector)
		{
			return GroupBy(source, keySelector, t => t, EqualityComparer<TKey>.Default);
		}

	
		/// <summary>
		/// Groups the elements of a sequence.
		/// </summary>
		/// <param name="source">An IEnumerable<T> whose elements to group.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="comparer">An IEqualityComparer<T> to compare keys with.</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <returns> A collection of elements where each element represents a projection over a group and its key.</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TSource>> GroupBy<TSource, TKey>(
					this IEnumerable<TSource> source,
					Func<TSource, TKey> keySelector,
					IEqualityComparer<TKey> comparer)
		{
			return GroupBy(source, keySelector, t => t, comparer);
		}

		
		/// <summary>
		 /// Groups the elements of a sequence.
		 /// </summary>
		 /// <param name="source">An IEnumerable<T> whose elements to group.</param>
		 /// <param name="keySelector">A function to extract the key for each element.</param>
		 /// <param name="elementSelector">A function to map each source element to an element in an IGrouping<TKey,TElement></param>
		 /// <typeparam name="TSource">Source type</typeparam>
		 /// <typeparam name="TKey">Key type</typeparam>
		 /// <typeparam name="TElement">Value type</typeparam>
		 /// <returns> A collection of elements where each element represents a projection over a group and its key.</returns>
		 /// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TElement>> GroupBy<TSource, TKey, TElement>(
				this IEnumerable<TSource> source,
				Func<TSource, TKey> keySelector,
				Func<TSource, TElement> elementSelector)
		{
			return GroupBy(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);
		}


		/// <summary>
		/// Groups the elements of a sequence.
		/// </summary>
		/// <param name="source">An IEnumerable<T> whose elements to group.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="elementSelector">A function to map each source element to an element in an IGrouping<TKey,TElement></param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <typeparam name="TElement">Value type</typeparam>
		/// <param name="comparer">An IEqualityComparer<T> to compare keys with.</param>
		/// <returns> A collection of elements  where each element represents a projection over a group and its key.</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static Dictionary<TKey, IEnumerable<TElement>> GroupBy<TSource, TKey, TElement>(
				this IEnumerable<TSource> source,
				Func<TSource, TKey> keySelector,
				Func<TSource, TElement> elementSelector,
				IEqualityComparer<TKey> comparer)
		{
			if (source == null || keySelector == null || elementSelector == null)
				throw new ArgumentNullException();

			Dictionary<TKey, IEnumerable<TElement>> res = new Dictionary<TKey, IEnumerable<TElement>>(comparer ?? EqualityComparer<TKey>.Default);

			foreach (TSource item in source)
			{
				var subset = source.Where(b => keySelector(b).Equals(keySelector(item))).Select(a => elementSelector(a)).ToList();
				if (!res.ContainsKey(keySelector(item)))
				{
					res.Add(keySelector(item), subset);
				}
			}
			return res;
		}

		/// <summary>
		/// Groups the elements of a sequence.
		/// </summary>
		/// <param name="source">An IEnumerable<T> whose elements to group.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="resultSelector">A function to create a result value from each group.</param>
		/// <param name="comparer">An IEqualityComparer<T> to compare keys with.</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <typeparam name="TResult">The type of the result value returned by resultSelector</typeparam>
		/// <returns> A collection of elements of type TResult where each element represents a projection over a group and its key.</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
					this IEnumerable<TSource> source,
					Func<TSource, TKey> keySelector,
					Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
		{
			return GroupBy(source, keySelector, t => t, resultSelector, EqualityComparer<TKey>.Default);
		}


		/// <summary>
		/// Groups the elements of a sequence.
		/// </summary>
		/// <param name="source">An IEnumerable<T> whose elements to group.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="resultSelector">A function to create a result value from each group.</param>
		/// <param name="comparer">An IEqualityComparer<T> to compare keys with.</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <typeparam name="TResult">The type of the result value returned by resultSelector</typeparam>
		/// <returns> A collection of elements of type TResult where each element represents a projection over a group and its key.</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
					this IEnumerable<TSource> source,
					Func<TSource, TKey> keySelector,
					Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
					IEqualityComparer<TKey> comparer)
		{
			return GroupBy(source, keySelector, t => t, resultSelector, comparer);
		}




		/// <summary>
		/// Groups the elements of a sequence.
		/// </summary>
		/// <param name="source">An IEnumerable<T> whose elements to group.</param>
		/// <param name="keySelector">A function to extract the key for each element.</param>
		/// <param name="elementSelector">A function to map each source element to an element in an IGrouping<TKey,TElement></param>
		/// <param name="resultSelector">A function to create a result value from each group.</param>
		/// <param name="comparer">An IEqualityComparer<T> to compare keys with.</param>
		/// <typeparam name="TSource">Source type</typeparam>
		/// <typeparam name="TKey">Key type</typeparam>
		/// <typeparam name="TElement">Value type</typeparam>
		/// <typeparam name="TResult">The type of the result value returned by resultSelector</typeparam>
		/// <returns> A collection of elements of type TResult where each element represents a projection over a group and its key.</returns>
		/// <exception cref="ArgumentNullException">If source, keySelector or element Selector is null</exception>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
					IEnumerable<TSource> source,
					Func<TSource, TKey> keySelector,
					Func<TSource, TElement> elementSelector,
					Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
					IEqualityComparer<TKey> comparer)
		{
			if (source == null || keySelector == null || elementSelector == null || resultSelector == null || comparer == null)
				throw new ArgumentNullException();

			List<TResult> res = new List<TResult>();

			foreach (TSource item in source)
			{
				var subset = source.Where(b => keySelector(b).Equals(keySelector(item))).Select(a => elementSelector(a)).ToList();
				if (!res.Contains(resultSelector(keySelector(item), subset)))
				{
					res.Add(resultSelector(keySelector(item), subset));
				}
			}
			return res;
		}
	}
}
