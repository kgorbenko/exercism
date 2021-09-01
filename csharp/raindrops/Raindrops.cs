using System;
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var map = new Dictionary<int, string> {
            {3, "Pling"},{5, "Plang"},{7, "Plong"}
        };

        string translated = "";

        foreach (var pair in map)
            if (number % pair.Key == 0)
                translated += pair.Value;


        if (translated.Equals(""))
            return number.ToString();

        return translated;
    }
}