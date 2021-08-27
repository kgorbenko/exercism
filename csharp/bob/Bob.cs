using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        bool IsQuestion(string statement) => statement.EndsWith("?");

        bool IsYell(string statement)
            => statement.Any(char.IsLetter) && statement.ToUpper() == statement;

        return statement.Trim() switch {
            var str when string.IsNullOrWhiteSpace(str) => "Fine. Be that way!",
            var str when IsYell(str) && IsQuestion(str) => "Calm down, I know what I'm doing!",
            var str when IsQuestion(str) => "Sure.",
            var str when IsYell(str) => "Whoa, chill out!",
            _ => "Whatever."
        };
    }
}