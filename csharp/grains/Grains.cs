using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        return (ulong) Math.Pow(x: 2, n - 1);
    }

    public static ulong Total()
        => Enumerable.Range(1, 64)
                     .Select(Square)
                     .Aggregate((x, y) => x + y);
}