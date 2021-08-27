using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        IEnumerable<int> GetMultiples(int multiple, int limit) =>
            Enumerable.Range(start: 1, limit / multiple)
                      .Select(x => x * multiple);

        return multiples.Where(x => x > 0)
                        .Select(x => GetMultiples(x, max - 1))
                        .SelectMany(x => x)
                        .Distinct()
                        .Sum();
    }
}