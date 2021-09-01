using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number));
        }

        return Count(number, steps: 0);
    }

    private static int Count(int number, int steps)
    {
        if (number == 1)
        {
            return steps;
        }

        return number % 2 == 0
            ? Count(number / 2, steps + 1)
            : Count(number * 3 + 1, steps + 1);
    }
}