using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
  public static partial class Extensions
  {
    public static T LastOrDefault<T>(this IEnumerable<T> self)
    {
      if (self == null) throw new ArgumentNullException(nameof(self));

      var iterator = self.GetEnumerator();

      if (iterator.MoveNext())
      {
        T result;
        do
        {
          result = iterator.Current;
        }
        while (iterator.MoveNext());
        return result;
      }
      return default(T);
    }

    public static T LastOrDefault<T>(this IEnumerable<T> self, Func<T, bool> predicate)
    {
      if (self == null || predicate == null) throw new ArgumentNullException(nameof(self));

      self = self.Where(predicate);

      var iterator = self.GetEnumerator();
      if (iterator.MoveNext())
      {
        T result;
        do
        {
          result = iterator.Current;
        }
        while (iterator.MoveNext());
        return result;
      }
      return default(T);
    }
  }
}