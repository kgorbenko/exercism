using System.Text;

public static class RotationalCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private const int AlphabetLenght = 26;

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

            var cypheredCharacter = char.IsLower(character)
                ? Alphabet[newCharacterPosition]
                : char.ToUpper(Alphabet[newCharacterPosition]);

            builder.Append(cypheredCharacter);
        }

        return builder.ToString();
    }

    private static int RemoveRedundantRotates(int shift)
    {
        return shift - AlphabetLenght * GetNumberOfRotates();

        int GetNumberOfRotates() => shift / AlphabetLenght;
    }
}