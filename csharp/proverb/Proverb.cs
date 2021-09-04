using System;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        var proverb = new string[subjects.Length];

        if (subjects.Length == 0) return proverb;
        if (subjects.Length == 1)
        {
            proverb[0] = $"And all for the want of a {subjects[0]}.";
            return proverb;
        }

        for (int i = 1; i < subjects.Length; i++)
            proverb[i-1] = $"For want of a {subjects[i-1]} the {subjects[i]} was lost.";

        proverb[subjects.Length - 1] = $"And all for the want of a {subjects[0]}.";

        return proverb;
    }
}