using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Takes the last count elements
        /// </summary>
        /// <param name="source">Set of elements from where the elements will be taken</param>
        /// <param name="count">Number of elements to be taken</param>
        /// <typeparam name="TSource">Source Type</typeparam>
        /// <returns>The last count elements</returns>
        /// <exception cref="ArgumentNullException">If source is null</exception>
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
        {
            if(source == null) throw new ArgumentNullException();
            var sourceEnumerator = source.GetEnumerator();
            var buffer = new TSource[count];
            int numOfItems = 0;
            int idx;

            for (idx = 0; (idx < count) && sourceEnumerator.MoveNext(); idx++, numOfItems++)
            {
                buffer[idx] = sourceEnumerator.Current;
            }

            if (numOfItems < count)
            {
                for (idx = 0; idx < numOfItems; idx++)
                {
                    yield return buffer[idx];
                }

                yield break;
            }
            
            if (numOfItems < count)
            {
                for (idx = 0; idx < numOfItems; idx++)
                {
                    yield return buffer[idx];
                }

                yield break;
            }
            
            for (idx = 0; sourceEnumerator.MoveNext(); idx = (idx + 1) % count)
            {
                buffer[idx] = sourceEnumerator.Current;
            }
            
            for (; numOfItems > 0; idx = (idx + 1) % count, numOfItems--)
            {
                yield return buffer[idx];
            }
            
        }
    }
}