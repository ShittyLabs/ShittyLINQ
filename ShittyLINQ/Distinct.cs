using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> self)
        {
            if (self == null) throw new ArgumentNullException();
            var newList = new List<T>();
            foreach (var currentItem in self)
            {
                if (!newList.Contains(currentItem))
                {
                    newList.Add(currentItem);
                }
            }

            return newList;
        }
    }
}