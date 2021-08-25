using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> highScores;

    public HighScores(List<int> highScores)
    {
        this.highScores = highScores ?? throw new ArgumentException(nameof(highScores));
    }

    public List<int> Scores() => highScores;

    public int Latest() => highScores.Last();

    public int PersonalBest() => highScores.Max();

    public List<int> PersonalTopThree()
        => highScores.OrderByDescending(x => x)
                     .Take(3)
                     .ToList();
}