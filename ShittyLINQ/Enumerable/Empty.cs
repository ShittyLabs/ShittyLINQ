using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Enumerable
    {
        /// <summary>
        /// The empty function.
        /// </summary>
        /// <typeparam name="T">The type of shit to assign to the type parameter of the returned shit</typeparam>
        /// <returns> Some empty shit of type <see cref="{T}"/></returns>
        public static IEnumerable<T> Empty<T> () => EmptyEnumerable<T>.Instance;

    }

    internal class EmptyEnumerable<T>
    {
        public static readonly T[] Instance = new T[0];
    }

}
