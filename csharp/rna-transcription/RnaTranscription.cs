using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
        => new string(nucleotide.Select(x => x switch
                                {
                                    'G' => 'C',
                                    'C' => 'G',
                                    'T' => 'A',
                                    'A' => 'U',
                                    var num => num
                                })
                                .ToArray());
}