using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    private static readonly (char Opening, char Closing)[] brackets = {
        ('(', ')'),
        ('{', '}'),
        ('[', ']')
    };

    private static char GetOpeningBracket(char closingBracket)
        => brackets.First(x => x.Closing == closingBracket).Opening;

    private static IEnumerable<char> GetOpeningBrackets()
        => brackets.Select(x => x.Opening);

    private static bool IsOpening(this char bracket)
        => GetOpeningBrackets().Contains(bracket);

    private static IEnumerable<char> GetClosingBrackets()
        => brackets.Select(x => x.Closing).ToArray();

    public static bool IsPaired(string input)
    {
        var bracketsStack = new Stack<char>();
        var allBrackets = GetOpeningBrackets().Concat(GetClosingBrackets());

        foreach (var character in input.Where(x => allBrackets.Contains(x)))
        {
            if (!character.IsOpening())
            {
                if (!bracketsStack.TryPeek(out var opening) || GetOpeningBracket(character) != opening)
                {
                    return false;
                }

                bracketsStack.Pop();
            } else
            {
                bracketsStack.Push(character);
            }
        }

        return !bracketsStack.Any();
    }
}