using System;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        var result = "";

        foreach (char c in nucleotide)
        {
            switch (c)
            {
                case 'G':
                    result += 'C';
                    break;

                case 'C':
                    result += 'G';
                    break;

                case 'T':
                    result += 'A';
                    break;

                case 'A':
                    result += 'U';
                    break;

                default:
                    result += c;
                    break;

            }
        }
        return result;
    }
}