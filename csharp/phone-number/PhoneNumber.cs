using System;
using System.Linq;

public static class PhoneNumber
{
    private static string RemoveCountryCode(this string number)
        => number.StartsWith("1")
            ? number.Remove(startIndex: 0, count: 1)
            : number;

    private static string ValidateLength(this string number)
        => number.Length != 10
            ? throw new ArgumentException(message: null, nameof(number))
            : number;

    private static string ValidateAreaCode(this string number)
        => number[index: 0] is '0' or '1'
            ? throw new ArgumentException()
            : number;

    private static string ValidateExchangeCode(this string number)
        => number[index: 3] is '0' or '1'
            ? throw new ArgumentException()
            : number;

    public static string Clean(string phoneNumber)
    {
        return string.Join("", phoneNumber.Where(char.IsNumber))
                     .RemoveCountryCode()
                     .ValidateLength()
                     .ValidateAreaCode()
                     .ValidateExchangeCode();
    }
}