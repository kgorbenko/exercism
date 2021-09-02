using System.Linq;

static class LogLine
{
    private static (string Level, string Message) Parse(string logLine)
    {
        var parts = logLine.Split(":")
                           .Select(x => x.Trim('[', ']'))
                           .Select(x => x.Trim())
                           .ToArray();

        return (Level: parts[0].ToLower(), Message: parts[1]);
    }

    public static string Message(string logLine)
        => Parse(logLine).Message;

    public static string LogLevel(string logLine)
        => Parse(logLine).Level;

    public static string Reformat(string logLine)
    {
        var (level, message) = Parse(logLine);

        return $"{message} ({level})";
    }
}
