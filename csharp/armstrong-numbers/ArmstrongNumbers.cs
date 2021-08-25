using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        double sum = 0;
        var stringNumber = number.ToString();

        foreach (char c in stringNumber)
        {
            sum = sum + Math.Pow(int.Parse(c.ToString()), stringNumber.Length); 
        }
        return number == sum;
    }
}