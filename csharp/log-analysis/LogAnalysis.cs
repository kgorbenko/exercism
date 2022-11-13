using System;

public static class LogAnalysis
{
    public static string SubstringAfter(this string value, string after) =>
        value[(value.IndexOf(after, StringComparison.Ordinal) + after.Length)..];

    public static string SubstringBetween(this string value, string after, string before)
    {
        var afterIndex = value.IndexOf(after, StringComparison.Ordinal) + after.Length;
        var beforeIndex = value.IndexOf(before, StringComparison.Ordinal);
        return value[afterIndex..beforeIndex];
    }

    public static string Message(this string logLine) =>
        logLine.SubstringAfter(": ");

    public static string LogLevel(this string logLine) =>
        logLine.SubstringBetween("[", "]");
}