﻿using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private const decimal BookPrice = 8m;

    private static readonly Dictionary<int, decimal> discounts = new Dictionary<int, decimal>
    {
        {1, 1.0m },
        {2, 0.95m },
        {3, 0.90m },
        {4, 0.80m },
        {5, 0.75m }
    };

    public static decimal Total(IEnumerable<int> books)
    {
        if (books.Count() == 0) return 0;

        var groups = GetAllGroups(books);

        return Enumerable.Min(groups.Select(group => GetGroupPrice(group)));
    }

    private static IEnumerable<int[]> GetAllGroups(IEnumerable<int> books)
    {
        var groups = new List<int[]>();

        for (int i = 1; i <= 5; i++)
        {
            var singleGroup = SortBooksByCount(books);
            var lengths = new List<int>();

            while (singleGroup.Count() != 0)
            {
                var uniqueBooks = singleGroup.Distinct().Take(i);
                singleGroup = singleGroup.RemoveBooks(uniqueBooks);
                lengths.Add(uniqueBooks.Count());
            }

            groups.Add(lengths.ToArray());
        }

        return groups;
    }

    private static IEnumerable<int> RemoveBooks(this IEnumerable<int> collection, IEnumerable<int> toRemove)
    {
        var collectionList = collection.ToList();

        foreach (var book in toRemove)
            collectionList.Remove(book);

        return collectionList;
    }

    private static IEnumerable<int> SortBooksByCount(IEnumerable<int> books)
        => books.GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .SelectMany(x => x);

    private static decimal GetGroupPrice(IEnumerable<int> groupsLengths)
        => groupsLengths.Sum(length => BookPrice * length * discounts[length]);
}