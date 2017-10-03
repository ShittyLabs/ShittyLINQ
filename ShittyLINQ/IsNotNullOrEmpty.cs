using System.Collections.Generic;
using System.Linq;

namespace ShittyLINQ
{
    public partial class Extensions
    {
        /// <summary>
        /// Determines whether the enumerable is not null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>false</c> if given collection is null or empty otherwise it returns <c>true</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }
    }
}