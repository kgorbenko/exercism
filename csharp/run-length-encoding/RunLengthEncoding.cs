using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public record struct EncodingState(StringBuilder Result, char CurrentCharacter, int CurrentCount);

public record struct DecodingCharacterEntry(char Character, int Count);

public static class RunLengthEncoding
{
    private static string EncodeChar(char character, int count) =>
        count > 1
            ? $"{count}{character}"
            : $"{character}";

    private static EncodingState EncodeAndAppendToResult(this EncodingState currentState, char? newCharacter = default) =>
        new(
            Result: currentState.Result.Append(EncodeChar(currentState.CurrentCharacter, currentState.CurrentCount)),
            CurrentCharacter: newCharacter ?? currentState.CurrentCharacter,
            CurrentCount: newCharacter.HasValue ? 1 : 0
        );

    public static string Encode(string input)
    {
        if (input is "")
            return "";

        var smth = "test";

        var initialState = new EncodingState(
            Result: new StringBuilder(),
            CurrentCharacter: input[0],
            CurrentCount: 0
        );

        return input.Aggregate(
            seed: initialState,
            func: (state, character) =>
                      character == state.CurrentCharacter
                          ? state with { CurrentCount = state.CurrentCount + 1 }
                          : state.EncodeAndAppendToResult(character)
            )
                    .EncodeAndAppendToResult()
                    .Result
                    .ToString();
    }

    private static (int, int) GetLength(char[] input, int startPosition)
    {
        var leadingLengthCharacters = input.Skip(startPosition).TakeWhile(char.IsDigit).ToArray();
        return (int.Parse(new string(leadingLengthCharacters)), leadingLengthCharacters.Length);
    }

    private static (DecodingCharacterEntry, int) ParseCharacterEntry(char[] encoded, int startPosition)
    {
        var (length, lengthCharacterCount) =
            char.IsDigit(encoded[startPosition])
                ? GetLength(encoded, startPosition)
                : (1, 0);

        var characterIndex = startPosition + lengthCharacterCount;
        var character = encoded[characterIndex];

        return (new DecodingCharacterEntry(character, length), characterIndex + 1);
    }

    private static string JoinStrings(this IEnumerable<string> strings) =>
        string.Join("", strings);

    private static string DecodeChar(char character, int count) =>
        new(Enumerable.Repeat(character, count).ToArray());

    public static string Decode(string input) =>
        ArrayProcessingExtensions.ProcessArray(
            startPosition: 0,
            source: input.ToArray(),
            exitPredicate: (position, source) => position == source.Length,
            processFunc: ParseCharacterEntry
        )
            .Select(x => DecodeChar(x.Character, x.Count))
            .JoinStrings();
}

public static class ArrayProcessingExtensions
{
    public static IEnumerable<TResult> ProcessArray<TSource, TResult>(
        int startPosition,
        TSource[] source,
        Func<int, TSource[], bool> exitPredicate,
        Func<TSource[], int, (TResult, int)> processFunc
    )
    {
        var position = startPosition;
        while (!exitPredicate(position, source))
        {
            var (result, newPosition) = processFunc(source, position);

            position = newPosition;
            yield return result;
        }
    }
}
