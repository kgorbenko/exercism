using System;

public class BinarySearch
{
    private int[] sequence;
    private int firstIndex;
    private int lastIndex;

    public BinarySearch(int[] input)
    {
        sequence = input;
        firstIndex = 0;
        lastIndex = input.Length - 1;
    }

    public int Find(int value)
    {
        if (sequence.Length == 0) return -1;
        int index = sequence.Length / 2;

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