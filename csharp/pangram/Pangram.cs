using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var upperCase = input.ToUpperInvariant();
        return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".All(index => upperCase.Contains(index));
    }
}