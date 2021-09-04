using System;
using System.Linq;
using System.Collections.Generic;

public static class ScrabbleScore
{
    private static Dictionary<int, char[]> map = new Dictionary<int, char[]>()
    {
        {1, new char[] {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' } },
        {2, new char[] {'D', 'G'} },
        {3, new char[] {'B', 'C', 'M', 'P'} },
        {4, new char[] {'F', 'H', 'V', 'W', 'Y'} },
        {5, new char[] {'K'} },
        {8, new char[] {'J', 'X'} },
        {10, new char[] {'Q', 'Z'} }
    };

    public static int Score(string input)
    {
        var score = 0;

        foreach (var letter in input.ToUpper())
        {
            foreach (var pair in map)
                if (pair.Value.Contains(letter)) score += pair.Key;
        }

        return score;
    }
}