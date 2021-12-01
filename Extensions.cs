using System;
using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static IEnumerable<TOut> CombinePairwise<TIn, TOut>(this IEnumerable<TIn> data, Func<TIn, TIn, TOut> func)
    {
        var enumerator = data.GetEnumerator();
        if (enumerator.MoveNext())
        {
            var t1 = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var t2 = enumerator.Current;
                yield return func.Invoke(t1, t2);
                t1 = t2;
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> SlidingWindow<T>(this IEnumerable<T> data, int count)
    {
        var enumerator = data.GetEnumerator();
        var window = new List<T>();
        for (int i = 0; i < count; i++) {
            window.Add(enumerator.Current);
            if (!enumerator.MoveNext())
                yield break;
        }

        do {
            yield return window;
            window = new List<T>(window.Skip(1));
            window.Add(enumerator.Current);
        } while(enumerator.MoveNext());
    }
}