using System.Linq;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (identifier is "")
            return "";

        var builder = new StringBuilder(identifier).ToCamelCase();

        foreach (var character in identifier)
        {
            builder.Replace($"{character}", ProcessCharacter(character));
        }

        return builder.ToString();
    }

    private static StringBuilder ToCamelCase(this StringBuilder builder)
    {
        if (builder.Length < 2)
            return builder;

        var charactersToUpper =
            Enumerable.Range(0, builder.Length - 2)
                      .Where(index => builder[index] is '-' && char.IsLower(builder[index + 1]))
                      .Select(index => builder[index + 1]);

        foreach (var character in charactersToUpper)
        {
            builder.Replace($"-{character}", $"-{char.ToUpperInvariant(character)}");
        }

        return builder;
    }

    private static string ProcessCharacter(char character) =>
        character switch {
            ' ' => "_",
            >= 'α' and <= 'ω' => "",
            var c when char.IsControl(c) => "CTRL",
            var c when !char.IsLetter(c) => "",
            var c => $"{c}"
        };
}