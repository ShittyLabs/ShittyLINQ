using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        #region primitives
        /// <summary>
        /// Sums a sequence of integers
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static int Sum(this IEnumerable<int> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of longs
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static long Sum(this IEnumerable<long> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of doubles
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static double Sum(this IEnumerable<double> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of floats
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static float Sum(this IEnumerable<float> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of decimals
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static decimal Sum(this IEnumerable<decimal> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current;
                }
            }

            return sum;
        }
        #endregion
        #region Nullable
        /// <summary>
        /// Sums a sequence of nullable integers
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static int? Sum(this IEnumerable<int?> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of nullable longs
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static long? Sum(this IEnumerable<long?> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of nullable doubles
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static double? Sum(this IEnumerable<double?> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of nullable floats
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static float? Sum(this IEnumerable<float?> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sums a sequence of nullable decimals
        /// </summary>
        /// <param name="self">The source sequence</param>
        /// <returns></returns>
        public static decimal? Sum(this IEnumerable<decimal?> self)
        {
            if (self == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = iterator.Current;

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += iterator.Current.GetValueOrDefault();
                }
            }

            return sum;
        }
        #endregion

        #region transforms
        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static int Sum<T>(this IEnumerable<T> self, Func<T, int> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current);
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static int? Sum<T>(this IEnumerable<T> self, Func<T, int?> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current).GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static long Sum<T>(this IEnumerable<T> self, Func<T, long> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current);
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static long? Sum<T>(this IEnumerable<T> self, Func<T, long?> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current).GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static float Sum<T>(this IEnumerable<T> self, Func<T, float> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current);
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static float? Sum<T>(this IEnumerable<T> self, Func<T, float?> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current).GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static double Sum<T>(this IEnumerable<T> self, Func<T, double> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current);
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static double? Sum<T>(this IEnumerable<T> self, Func<T, double?> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current).GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static decimal Sum<T>(this IEnumerable<T> self, Func<T, decimal> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current);
                }
            }

            return sum;
        }

        /// <summary>
        /// Sum an enumerable of <typeparamref name="T"/> using transform function <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence</typeparam>
        /// <param name="self">The source sequence</param>
        /// <param name="predicate">The predicate to evaluate items</param>
        /// <returns></returns>
        public static decimal? Sum<T>(this IEnumerable<T> self, Func<T, decimal?> predicate)
        {
            if (self == null || predicate == null) throw new ArgumentNullException();

            var iterator = self.GetEnumerator();
            if (!iterator.MoveNext()) throw new InvalidOperationException("The sequence is empty.");

            var sum = predicate(iterator.Current);

            checked
            {
                while (iterator.MoveNext())
                {
                    sum += predicate(iterator.Current).GetValueOrDefault();
                }
            }

            return sum;
        }
        #endregion
    }
}
