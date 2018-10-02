using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static System.Collections.Generic.IEnumerable<TSource> Reverse<TSource>(this System.Collections.Generic.IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            
            for(var i = (int) source.Count() - 1; i >= 0; i--)
            {
                yield return source.ElementAt(i);
            }
        }
    }
}
