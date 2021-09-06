public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0)
        {
            return -1;
        }

        var firstIndex = 0;
        var lastIndex = input.Length - 1;

        while (firstIndex <= lastIndex)
        {
            var currentIndex = (lastIndex + firstIndex) / 2;
            var comparer = value.CompareTo(input[currentIndex]);

            if (comparer == 0)
            {
                return currentIndex;
            }

            (firstIndex, lastIndex) = comparer < 0
                ? (firstIndex, currentIndex - 1)
                : (currentIndex + 1, lastIndex);
        }

        return -1;
    }
}