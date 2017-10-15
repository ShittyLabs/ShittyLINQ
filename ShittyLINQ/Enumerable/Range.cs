using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Creates a collection of integers from [start, start + count)
        /// </summary>
        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count must be a non-negative integer.");
            }

            if (int.MaxValue - start + 1 < count)
            {
                throw new ArgumentOutOfRangeException("Generates integers that are larger than the maximum value.");
            }

            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }
    }
}
