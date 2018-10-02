using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
  public static partial class Extensions
  {
    public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> self, Func<T, bool> predicate)
    {
      if (self == null || predicate == null) throw new ArgumentNullException();

      using (var enumerator = self.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          if (!predicate(enumerator.Current))
          {
            yield return enumerator.Current;
          }
        }
      }

    }

    public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> self, Func<T, int, bool> predicate)
    {
      if (self == null || predicate == null) throw new ArgumentNullException();

      using (var enumerator = self.GetEnumerator())
      {
        var index = 0;
        while (enumerator.MoveNext())
        {
          if (!predicate(enumerator.Current, index))
          {
            yield return enumerator.Current;
          }
          index++;
        }
      }

    }
  }
}
