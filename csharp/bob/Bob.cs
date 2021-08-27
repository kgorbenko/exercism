using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
            return "Fine. Be that way!";

        if (statement.ToUpper().Equals(statement) && statement.Any(x => char.IsLetter(x)))
            return "Whoa, chill out!";

        if (statement.Trim().EndsWith("?"))
            return "Sure.";

        return "Whatever.";
    }
}