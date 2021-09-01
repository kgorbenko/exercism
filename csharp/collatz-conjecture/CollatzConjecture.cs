using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int numberOfSteps = 0;

        if (number <= 0) throw new ArgumentException();

        while (number != 1)
        {
            if (number % 2 == 0) number = number / 2;
            else number = number * 3 + 1;

            numberOfSteps++;
        }
        return numberOfSteps;
    }
}