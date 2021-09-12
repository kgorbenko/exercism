using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private const decimal BookPrice = 8m;

    private static readonly Dictionary<int, decimal> discounts = new() {
        { 1, 1.0m },
        { 2, 0.95m },
        { 3, 0.90m },
        { 4, 0.80m },
        { 5, 0.75m }
    };

    public static decimal Total(IEnumerable<int> books)
        => books.Any()
            ? GetGroupLengths(books.ToArray()).Select(GetGroupPrice).Min()
            : 0;

    private static IEnumerable<int[]> GetGroupLengths(IEnumerable<int> books)
        => Enumerable.Range(1, discounts.Count)
                     .Select(maxGroupCount => GetGroups(books.SortByCount(), maxGroupCount)
                                              .Select(x => x.Length)
                                              .ToArray());

    private static IEnumerable<int[]> GetGroups(IEnumerable<int> books, int maxGroupCount)
    {
        if (!books.Any())
        {
            return Enumerable.Empty<int[]>();
        }

        var group = GetNextGroup(books, maxGroupCount).ToArray();

        return new[] { group }.Concat(GetGroups(books.Remove(group), maxGroupCount));
    }

    private static IEnumerable<int> Remove(this IEnumerable<int> books, IEnumerable<int> toRemove)
    {
        var list = books.ToList();

        foreach (var itemToRemove in toRemove)
        {
            list.Remove(itemToRemove);
        }

        return list;
    }

    private static IEnumerable<int> SortByCount(this IEnumerable<int> books)
        => books.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .SelectMany(x => x);

    private static IEnumerable<int> GetNextGroup(IEnumerable<int> books, int maxGroupCount)
        => books.GroupBy(x => x)
                .Where(group => group.Any())
                .Take(maxGroupCount)
                .Select(x => x.Key);

    private static decimal GetGroupPrice(IEnumerable<int> groupsLengths)
        => groupsLengths.Sum(length => BookPrice * length * discounts[length]);
}