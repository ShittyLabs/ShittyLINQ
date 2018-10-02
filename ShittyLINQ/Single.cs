using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
  public static partial class Extensions
  {
    public static T Single<T>(this IEnumerable<T> self)
    {
      if (self == null) throw new ArgumentNullException();
      using (IEnumerator<T> e = self.GetEnumerator())
      {
        if (!e.MoveNext())
        {
          throw new InvalidOperationException();
        }

        T result = e.Current;
        if (!e.MoveNext())
        {
          return result;
        }
        throw new InvalidOperationException();
      }
    }

    public static T Single<T>(this IEnumerable<T> self, Func<T, bool> predicate)
    {
      if (self == null || predicate == null) throw new ArgumentNullException();

      return self.Where(predicate).Single();
    }
  }
}
