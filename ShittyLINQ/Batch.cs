using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> self, int bucketSize)
        {
            if (bucketSize <= 0)
                throw new ArgumentOutOfRangeException("The batch size should be greather than 0");

            var currentBatch = new List<T>();

            foreach (var item in self)
            {
                currentBatch.Add(item);

                if (currentBatch.Count >= bucketSize)
                {
                    yield return currentBatch;
                    currentBatch = new List<T>();
                }
            }

            if (currentBatch.Count > 0)
            {
                yield return currentBatch;
                currentBatch = new List<T>();
            }
        }
    }
}
