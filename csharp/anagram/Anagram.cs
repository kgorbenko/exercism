using System;
using System.Linq;

public class Anagram {
    private readonly string baseWord;
    private readonly string normalizedBaseWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
        normalizedBaseWord = Normalize(baseWord);
    }

    private static string Normalize(string value) =>
        new(
            value.ToUpperInvariant()
                 .OrderBy(x => x)
                 .ToArray()
        );

    private bool IsAnagram(string match) =>
        !match.Equals(baseWord, StringComparison.OrdinalIgnoreCase)
        && match.Length == baseWord.Length
        && Normalize(match) == normalizedBaseWord;

    public string[] FindAnagrams(string[] potentialMatches) =>
        potentialMatches.Where(IsAnagram)
                        .ToArray();
}