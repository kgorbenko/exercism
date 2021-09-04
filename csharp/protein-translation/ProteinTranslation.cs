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

    private static IEnumerable<string> GetCodons(string strand, int codonSize)
        => Enumerable.Range(start: 0, count: strand.Length / codonSize)
                     .Select(x => strand[(x * codonSize) .. (x * codonSize + codonSize)]);

    public static string[] Proteins(string strand)
        => GetCodons(strand, codonSize: 3)
           .TakeWhile(x => !terminatingCodons.Contains(x))
           .Select(x => codonToProteinMap[x])
           .ToArray();
}