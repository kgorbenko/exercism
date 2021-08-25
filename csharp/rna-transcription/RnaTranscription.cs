using System;

public static class Complement
{
    public static string OfDna(string nucleotide)
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