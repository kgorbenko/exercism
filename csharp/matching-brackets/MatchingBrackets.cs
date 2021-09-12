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

        return IsPaired(new string(input.Where(allBrackets.Contains).ToArray()), bracketsStack);
    }

    private static bool IsPaired(string input, Stack<char> stack)
    {
        if (input.Length == 0)
        {
            return !stack.Any();
        }

        var bracket = input[0];

        if (bracket.IsOpening())
        {
            stack.Push(bracket);
            return IsPaired(input[1..], stack);
        }

        if (stack.TryPeek(out var opening) && GetOpeningBracket(bracket) == opening)
        {
            stack.Pop();
            return IsPaired(input[1..], stack);
        }

        return false;
    }
}