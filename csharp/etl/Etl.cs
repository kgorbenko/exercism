using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var newSystem = new Dictionary<string, int>();
        
        foreach (var pair in old)
        {
            foreach (var letter in pair.Value)
            {
                newSystem.Add(letter.ToLower(), pair.Key);
            }
        }

        return newSystem;
    }
}