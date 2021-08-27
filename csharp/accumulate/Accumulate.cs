using System;
using System.Collections.Generic;
using System.Linq;

public static class AccumulateExtensions
{
    public static IEnumerable<Outcome> Accumulate<Income, Outcome>(this IEnumerable<Income> collection, Func<Income, Outcome> func)
    {
        foreach (var income in collection)

            yield return func(income);
    }
}