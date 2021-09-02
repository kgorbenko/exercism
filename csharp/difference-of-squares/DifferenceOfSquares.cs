using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var sum = Enumerable.Range(start: 1, max).Sum();

        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
        => Enumerable.Range(start: 1, max)
                     .Select(x => x * x)
                     .Sum();

    public static int CalculateDifferenceOfSquares(int max)
        => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}