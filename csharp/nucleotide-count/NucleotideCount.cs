using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        if (!IsSequenceValid(sequence))
        {
            throw new ArgumentException(nameof(sequence));
        }

        return string.Concat(sequence, "ACGT")
                     .GroupBy(x => x)
                     .ToDictionary(x => x.Key, x => x.Count() - 1);
    }

    private static bool IsSequenceValid(string sequence)
        => sequence.All(x => "ACGT".Contains(x));
}