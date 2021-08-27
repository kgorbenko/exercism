using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length == 0) throw new ArgumentException("Empty input string");
        if (sliceLength <= 0) throw new ArgumentException("Slice length can not be less then or equal to 0");
        if (sliceLength > numbers.Length) throw new ArgumentException("Slice length can not be more than numbers string length");

        var slices = new List<string>();

        for (int i = 0; i <= numbers.Length - sliceLength; i++)
            slices.Add(numbers.Substring(i, sliceLength));

        return slices.ToArray();
    }
}