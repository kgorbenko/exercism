using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string[]> map = new Dictionary<string, string[]>()
    {
        {"Methionine", new string[]{"AUG"} },
        {"Phenylalanine", new string[]{"UUU", "UUC"} },
        {"Leucine", new string[]{"UUA", "UUG"} },
        {"Serine", new string[]{"UCU", "UCC", "UCA", "UCG"} },
        {"Tyrosine", new string[]{"UAU", "UAC"} },
        {"Cysteine", new string[]{"UGU", "UGC"} },
        {"Tryptophan", new string[]{"UGG"}},
        {"STOP", new string[]{"UAA", "UAG", "UGA" } }
    };

    public static string[] Proteins(string strand)
    {
        var codons = DivideStrandToCodons(strand).ToArray();
        var proteins = new List<string>();

        foreach (var codon in codons)
        {
            if (map["STOP"].Contains(codon)) return proteins.ToArray();

            foreach (var pair in map)
            {
                if (pair.Value.Contains(codon)) proteins.Add(pair.Key);
            }
        }

        return proteins.ToArray();
    }

    private static IEnumerable<string> DivideStrandToCodons(string strand)
    {
        var startIndex = 0;

        for (int i = 0; i < strand.Length / 3; i++)
        {
            yield return strand.Substring(startIndex, 3);
            startIndex += 3;
        }
    }
}