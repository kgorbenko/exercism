using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var text = number.ToString();
        var power = text.Length;
        var sumOfPowers = text.Select(x => int.Parse($"{x}"))
                              .Select(x => (int) Math.Pow(x, power))
                              .Sum();

        return number == sumOfPowers;
    }
}