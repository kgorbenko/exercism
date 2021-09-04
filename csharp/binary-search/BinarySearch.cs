using System;

public static class BinarySearch
{
    public static int Find(int[] sequence, int value)
    {
        if (sequence.Length == 0) return -1;
        int index = sequence.Length / 2;

        var firstIndex = 0;
        var lastIndex = sequence.Length - 1;

        while (firstIndex <= lastIndex)
        {
            index = (lastIndex + firstIndex) / 2;

            int comparer = value.CompareTo(sequence[index]);
            if (comparer == 0) return index;
            if (comparer < 0) lastIndex = index - 1;
            if (comparer > 0) firstIndex = index + 1;
        }
        return -1;
    }
}