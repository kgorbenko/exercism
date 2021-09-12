using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private const int SeriesLength = 5;
    private const decimal BookPrice = 8m;

    public static decimal Total(IEnumerable<int> books)
    {
        var booksArray = books.ToArray();

        return booksArray.Any()
            ? GetGroupLengths(booksArray).Select(GetGroupPrice).Min()
            : 0;
    }

    private static decimal GetGroupPrice(IEnumerable<int> groupsLengths)
        => groupsLengths.Sum(length => BookPrice * length * GetDiscount(length));

    private static decimal GetDiscount(int booksCount)
        => booksCount switch {
            1 => 1.0m,
            2 => 0.95m,
            3 => 0.90m,
            4 => 0.80m,
            5 => 0.75m,
            _ => throw new InvalidOperationException("Invalid number of books. Cannot count discount.")
        };

    private static IEnumerable<IEnumerable<int>> GetGroupLengths(int[] books)
        => Enumerable.Range(start: 1, count: SeriesLength)
                     .Select(maxGroupCount => books.SortByCount()
                                                   .GetGroups(maxGroupCount)
                                                   .Select(x => x.Length));

    private static IEnumerable<int> SortByCount(this IEnumerable<int> books)
        => books.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .SelectMany(x => x);

    private static IEnumerable<int[]> GetGroups(this IEnumerable<int> books, int maxGroupCount)
    {
        var booksArray = books.ToArray();

        if (!booksArray.Any())
        {
            return Enumerable.Empty<int[]>();
        }

        var group = GetNextGroup(booksArray, maxGroupCount).ToArray();

        return new[] { group }.Concat(GetGroups(booksArray.RemoveOnce(group), maxGroupCount));
    }

    private static IEnumerable<int> RemoveOnce(this IEnumerable<int> books, IEnumerable<int> toRemove)
    {
        var list = new List<int>(books);

        foreach (var itemToRemove in toRemove)
        {
            list.Remove(itemToRemove);
        }

        return list;
    }

    private static IEnumerable<int> GetNextGroup(IEnumerable<int> books, int maxGroupCount)
        => books.GroupBy(x => x)
                .Where(group => group.Any())
                .Take(maxGroupCount)
                .Select(x => x.Key);
}