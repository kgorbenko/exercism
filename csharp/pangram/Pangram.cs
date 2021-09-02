using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var upperCase = input.ToUpper();

        return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".All(index => upperCase.Contains(index));
    }
}