using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Calculates the average nummeric value
        /// of an IEnumerable collection.
        /// </summary>
        private static R Average<R, T>(this IEnumerable<T> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            dynamic sum = default(R);
            int count = 0;

            foreach (var number in self)
            {
                sum += number;
                count++;
            }

            if (count == 0)
            {
                throw new InvalidOperationException("The sequence is empty.");
            }

            return sum / count;
        }

        public static double Average(this IEnumerable<int> self)
        {
            return self.Average<double, int>();
        }

        public static float Average(this IEnumerable<float> self)
        {
            return self.Average<float, float>();
        }

        public static double Average(this IEnumerable<double> self)
        {
            return self.Average<double, double>();
        }

        public static double Average(this IEnumerable<long> self)
        {
            return self.Average<double, long>();
        }
    }
}
