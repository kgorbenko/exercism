using System;
using System.Linq;

public static class RomanNumeralExtension
{
    private static string ToRomanLiteral(int value) =>
        value switch
        {
            1 => "I",
            5 => "V",
            10 => "X",
            50 => "L",
            100 => "C",
            500 => "D",
            1000 => "M",
            _ => throw new ArgumentOutOfRangeException(nameof(value))
        };

    private static string WithValueBefore(string before, string value) => $"{before}{value}";

    private static string Repeat(string value, int times) => string.Join("", Enumerable.Repeat(value, times));

    private static string DigitToRoman(int digit, int order)
    {
        int ToOrder(int value) => value * (int) Math.Pow(10, order);

        string OneRoman() => ToRomanLiteral(ToOrder(1));
        string FiveRoman() => ToRomanLiteral(ToOrder(5));
        string TenRoman() => ToRomanLiteral(ToOrder(10));

        return digit switch
        {
            < 4 => Repeat(OneRoman(), digit),
            4 => WithValueBefore(OneRoman(), FiveRoman()),
            5 => FiveRoman(),
            < 9 => WithValueBefore(FiveRoman(), Repeat(OneRoman(), digit - 5)),
            9 => WithValueBefore(OneRoman(), TenRoman()),
            _ => throw new ArgumentOutOfRangeException(nameof(digit))
        };
    }

    public static string ToRoman(this int value) =>
        string.Concat(
            value.ToString()
                .Reverse()
                .Select(x => int.Parse($"{x}"))
                .Select(DigitToRoman)
                .Reverse()
        );
}