using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number));
        }

        var aliquotSum = Enumerable.Range(1, number / 2)
                                   .Select(x => number % x == 0 ? x : 0)
                                   .Sum();

        return aliquotSum switch {
            var s when s == number => Classification.Perfect,
            var s when s > number => Classification.Abundant,
            _ => Classification.Deficient
        };
    }
}
