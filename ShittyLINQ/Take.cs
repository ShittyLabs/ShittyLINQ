using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static IEnumerable<T> Take<T>(this IEnumerable<T> self, int count)
        {
            if(self == null) throw new ArgumentNullException();
            
            using (var enumerator = self.GetEnumerator())
            {
                int index = 0;
                while (enumerator.MoveNext())
                {
                    if (index < count)
                    {
                        yield return enumerator.Current;
                        index++;
                    }
                }
            }
            
        }
    }
}
