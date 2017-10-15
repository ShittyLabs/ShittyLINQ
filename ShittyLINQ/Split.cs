using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public partial class Extensions
    {
        /// <summary>
        /// Splits the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="partitionBy">The partition by.</param>
        /// <param name="removeEmptyEntries">if set to <c>true</c> empty entries will be removed.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <example>
        /// startToEndCollection.Split(f =&gt; f.DayOfWeek == DayOfWeek.Saturday || f.DayOfWeek == DayOfWeek.Sunday, true)
        /// </example>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> partitionBy, bool removeEmptyEntries = false, int count = -1)
        {
            var yielded = 0;
            var items = new List<TSource>();
            foreach (var item in source)
            {
                if (!partitionBy(item))
                    items.Add(item);
                else if (!removeEmptyEntries || items.Count > 0)
                {
                    yield return items.ToArray();
                    items.Clear();

                    if (count > 0 && ++yielded == count) yield break;
                }
            }

            if (items.Count > 0) yield return items.ToArray();
        }
    }
}