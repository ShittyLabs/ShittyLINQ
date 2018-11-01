using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static int Sum(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("Source is null.");

            int sum = 0;

            foreach(var value in source)
            {
                sum += value;
            }

            return sum;
        }
    }
}
