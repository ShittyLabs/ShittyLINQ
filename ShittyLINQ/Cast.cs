namespace ShittyLINQ
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static partial class Extensions
    {
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            if (source is IEnumerable<TResult> results)
            {
                foreach (var result in results)
                    yield return result;
            }

            foreach (TResult result in source)
                yield return result;
        }
    }
}