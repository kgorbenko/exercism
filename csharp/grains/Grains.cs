using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        ulong onCertainSquare = 1;

        for (int i = 2; i <= n; i++)
        {
            onCertainSquare = onCertainSquare * 2;
        }

        return onCertainSquare;
    }

    public static ulong Total()
    {
        ulong sum = 0;
        ulong onCertainSquare = 1;

        for (int i = 2; i <= 64; i++)
        {
            onCertainSquare = onCertainSquare * 2;
            sum = sum + onCertainSquare;
        }

        return sum + 1;
    }
    
}