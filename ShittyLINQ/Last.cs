using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
  public static partial class Extensions
  {
    public static T Last<T>(this IEnumerable<T> self)
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
      throw new InvalidOperationException("The source sequence is empty.");
    }

    public static T Last<T>(this IEnumerable<T> self, Func<T, bool> predicate)
    {
      if (self == null || predicate == null) throw new ArgumentNullException(nameof(self));

      if (self.Count() == 0) throw new InvalidOperationException("The source sequence is empty.");

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

      throw new InvalidOperationException("No matching element in source sequence.");
    }
  }
}