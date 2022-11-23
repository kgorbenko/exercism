using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var cleanedWord = word.Replace(" ", "").Replace("-", "");
        return cleanedWord.Length == cleanedWord.ToUpperInvariant().Distinct().Count();
    }
}
