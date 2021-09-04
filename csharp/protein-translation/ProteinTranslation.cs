using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> codonToProteinMap = new() {
        ["AUG"] = "Methionine",
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan"
    };

    private static readonly HashSet<string> terminatingCodons = new(new[] {
        "UAA",
        "UAG",
        "UGA"
    });

    public static string[] Proteins(string strand)
        => Enumerable.Range(start: 0, count: strand.Length / 3)
                     .Select(x => strand.Substring(startIndex: x * 3, length: 3))
                     .TakeWhile(x => !terminatingCodons.Contains(x))
                     .Select(x => codonToProteinMap[x])
                     .ToArray();
}