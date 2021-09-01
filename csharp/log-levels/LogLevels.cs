using System;
using System.Linq;

static class LogLine
{
    private static readonly string[] availableLogLevels = { "info", "warning", "error" };

    private static (string Level, string Message) Parse(string logLine)
    {
        var level = availableLogLevels.First(x => logLine.Contains($"[{x}]", StringComparison.OrdinalIgnoreCase));
        var message = logLine.Replace(oldValue: $"[{level}]:", newValue: "", StringComparison.OrdinalIgnoreCase)
                             .Trim();

        return (Level: level, Message: message);
    }

    public static string Message(string logLine)
        => Parse(logLine).Message;

    public static string LogLevel(string logLine)
        => Parse(logLine).Level;

    public static string Reformat(string logLine)
    {
        var (level, message) = Parse(logLine);

        return $"{message} ({level.ToLower()})";
    }
}
