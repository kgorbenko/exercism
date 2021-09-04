using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
        => subjects.Length == 0
            ? Array.Empty<string>()
            : Enumerable.Range(start: 1, subjects.Length - 1)
                        .Select(i => $"For want of a {subjects[i - 1]} the {subjects[i]} was lost.")
                        .Append($"And all for the want of a {subjects[0]}.")
                        .ToArray();
}