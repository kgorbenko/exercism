using System.Text;
using System.Linq;

public static class RotationalCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    private static char CypherCharacter(char character, int shiftKey)
    {
        static int GetNumberOfRotates(int index) => index / Alphabet.Length;

        static int RemoveRedundantRotates(int index) => index - Alphabet.Length * GetNumberOfRotates(index);

        static char GetNewCharacter(int characterPosition, bool isLower) =>
            isLower
                ? Alphabet[characterPosition]
                : char.ToUpper(Alphabet[characterPosition]);

        var shiftedIndex = Alphabet.IndexOf(char.ToLower(character)) + shiftKey;
        var newCharacterPosition = RemoveRedundantRotates(shiftedIndex);
        return GetNewCharacter(newCharacterPosition, char.IsLower(character));
    }

    public static string Rotate(string text, int shiftKey) =>
        text.Aggregate(new StringBuilder(), (result, character) =>
            result.Append(
                !Alphabet.Contains(char.ToLower(character))
                    ? character
                    : CypherCharacter(character, shiftKey))
            ).ToString();
}