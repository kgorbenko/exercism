using System;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int i = 1;
        int sum = 0;
        while (i <= max)
        {
            sum = sum + i;
            i++;
        }
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        int i = 1;
        int sum = 0;
        while (i <= max)
        {
            sum = sum + i * i;
            i++;
        }
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}