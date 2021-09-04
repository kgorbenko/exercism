using System.Linq;

public static class ScrabbleScore
{
    private static readonly (int Points, char[] Letters)[] pointsNumberToLetters = {
        (1, new[] { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' }),
        (2, new[] { 'D', 'G' }),
        (3, new[] { 'B', 'C', 'M', 'P' }),
        (4, new[] { 'F', 'H', 'V', 'W', 'Y' }),
        (5, new[] { 'K' }),
        (8, new[] { 'J', 'X' }),
        (10, new[] { 'Q', 'Z' })
    };

    public static int Score(string input)
        => pointsNumberToLetters.Sum(pointsToLetters
            => input.Count(letter => pointsToLetters.Letters.Contains(char.ToUpper(letter)))
            * pointsToLetters.Points);
}