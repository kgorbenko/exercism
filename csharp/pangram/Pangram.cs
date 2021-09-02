using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var upperCase = input.ToUpper();

        return Enumerable.Range(65, 26).All(index => upperCase.Contains((char) index));
    }   
}