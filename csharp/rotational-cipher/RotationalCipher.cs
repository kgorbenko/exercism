using System.Text;

public static class RotationalCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static string Rotate(string text, int shiftKey)
    {
        var builder = new StringBuilder();

        foreach (var character in text)
        {
            if (!Alphabet.Contains(char.ToLower(character)))
            {
                builder.Append(character);
                continue;
            }

            var shiftedIndex = Alphabet.IndexOf(char.ToLower(character)) + shiftKey;
            var newCharacterPosition = RemoveRedundantRotates(shiftedIndex);
            var cypheredCharacter = GetNewCharacter(newCharacterPosition, char.IsLower(character));

            builder.Append(cypheredCharacter);
        }

        return builder.ToString();
    }

    private static int GetNewCharacter(int characterPosition, bool isLower)
        => isLower
            ? Alphabet[characterPosition]
            : char.ToUpper(Alphabet[characterPosition]);

    private static int RemoveRedundantRotates(int index)
    {
        int GetNumberOfRotates() => index / Alphabet.Length;

        return index - Alphabet.Length * GetNumberOfRotates();
    }
}