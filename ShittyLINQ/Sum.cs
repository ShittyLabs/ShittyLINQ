using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static int Sum(this IEnumerable<int> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0;

            foreach (var element in self)
            {
                sum += element;
            }

            return sum;
        }

        public static double Sum(this IEnumerable<double> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0d;

            foreach (var element in self)
            {
                sum += element;
            }

            return sum;
        }

        public static float Sum(this IEnumerable<float> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0f;

            foreach (var element in self)
            {
                sum += element;
            }

            return sum;
        }

        public static int Sum<T>(this IEnumerable<T> self, Func<T, int?> selector)
        {
            if (self == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0;

            foreach (var element in self)
            {
                sum += selector(element).GetValueOrDefault();
            }

            return sum;
        }

        public static double Sum<T>(this IEnumerable<T> self, Func<T, double?> selector)
        {
            if (self == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0d;

            foreach (var element in self)
            {
                sum += selector(element).GetValueOrDefault();
            }

            return sum;
        }

        public static float Sum<T>(this IEnumerable<T> self, Func<T, float?> selector)
        {
            if (self == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0f;

            foreach (var element in self)
            {
                sum += selector(element).GetValueOrDefault();
            }

            return sum;
        }
    }
}