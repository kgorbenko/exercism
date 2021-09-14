using System;
using System.Linq;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
        => string.Join("\n\n", Enumerable.Range(startBottles - takeDown + 1, takeDown)
                                         .Select(GetVerse)
                                         .Reverse()
                                         .ToArray());

    private static string GetVerse(int bottles)
    {
        return bottles switch {
            var n and > 2 => $"{n} bottles of beer on the wall, {n} bottles of beer.\n" +
                                $"Take one down and pass it around, {n - 1} bottles of beer on the wall.",
            2 => "2 bottles of beer on the wall, 2 bottles of beer.\n" +
                 "Take one down and pass it around, 1 bottle of beer on the wall.",
            1 => "1 bottle of beer on the wall, 1 bottle of beer.\n" +
                 "Take it down and pass it around, no more bottles of beer on the wall.",
            0 => "No more bottles of beer on the wall, no more bottles of beer.\n" +
                 "Go to the store and buy some more, 99 bottles of beer on the wall.",
            _ => throw new ArgumentOutOfRangeException(nameof(bottles))
        };
    }
}