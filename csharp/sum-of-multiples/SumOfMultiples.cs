using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var sum = 0;
        var invalidNumbers = new List<int>();

        foreach (var c in multiples)
        {
            for (var i = c; i < max; i += c)
            {
                if ((i % c) == 0 && i < max && !invalidNumbers.Contains(i))
                {
                    invalidNumbers.Add(i);
                    sum += i;
                }
            }
        }

        return sum;
    }
}