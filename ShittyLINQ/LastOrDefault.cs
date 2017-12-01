using System;
using System.Collections.Generic;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        public static T LastOrDefault<T>(this IEnumerable<T> self, T defaultValue)
        {
            if (self == null) throw new ArgumentNullException();
            using (var iterator = self.GetEnumerator())
            {
                if (!iterator.MoveNext()) return defaultValue;
                var result = iterator.Current;
                while (iterator.MoveNext())
                {
                    result = iterator.Current;
                }
                return result;
            }
        }

        public static T LastOrDefault<T>(this IEnumerable<T> self)
        {
            return LastOrDefault(self, default(T));
        }
    }
}
