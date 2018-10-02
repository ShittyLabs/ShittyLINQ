using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{

  public static partial class Extensions
  {
    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> self, int count)
    {

      if (self == null) throw new ArgumentNullException(nameof(self));

      var lastIndex = self.Count() - count;
      var index = 0;
      using (var e = self.GetEnumerator())
      {
        while (e.MoveNext() && index < lastIndex)
        {
          index++;
          yield return e.Current;
        }
      }
    }
  }
}
