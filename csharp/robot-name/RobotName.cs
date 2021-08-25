using System;
using System.Collections.Generic;

public class Robot
{
    private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private static readonly Random random = new Random();
    private static readonly HashSet<string> occupiedNames = new HashSet<string>();

    public string Name { get; private set; }

    public Robot()
    {
        Reset();
    }

    public void Reset()
    {
        Name = GetName();
        occupiedNames.Add(Name);
    }

    private static string GetName()
    {
        var name = GenerateName();

        while (occupiedNames.Contains(name))
        {
            name = GenerateName();
        }

        return name;
    }

    private static string GenerateName() => $"{GenerateRandomLetter()}{GenerateRandomLetter()}{GenerateRandomNumber():D3}";

    private static char GenerateRandomLetter() => Letters[random.Next(Letters.Length)];

    private static int GenerateRandomNumber() => random.Next(maxValue: 1000);
}