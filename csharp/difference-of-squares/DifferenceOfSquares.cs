using System;

public static class Squares
{
    public static int SquareOfSums(int max)
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

    public static int SumOfSquares(int max)
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

    public static int DifferenceOfSquares(int max)
    {
        return SquareOfSums(max) - SumOfSquares(max); 
    }
}