using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase) =>
        new(phrase.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(RemovePunctuation)
                  .Select(x => char.ToUpperInvariant(x[0]))
                  .ToArray());

    private static string RemovePunctuation(this string phrase) =>
        new(phrase.Where(character => !char.IsPunctuation(character))
                  .ToArray());
}