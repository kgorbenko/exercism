using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<TU> Accumulate<T, TU>(this IEnumerable<T> collection, Func<T, TU> func)
    {
        foreach (var income in collection)
        {
            yield return func(income);
        }
    }
}