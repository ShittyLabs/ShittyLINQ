using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
     public static partial class Extensions
     {
        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new System.ArgumentNullException(nameof(source));
            long count = source.Count();
            T[] array = new T[count];
            for(int i = 0; i < count; i ++)
            {
                array[i] = source.ElementAt(i);
            }
            return array;
        }
    }
}
