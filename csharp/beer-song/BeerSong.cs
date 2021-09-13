using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var song = new StringBuilder();
        int bottles = startBottles;

        for (int i = 0; i < takeDown; i++)
        {
            var firstLine = GetFirstLine(bottles);
            var secondLine = GetSecondLine(bottles);

            bottles -= 1;
            song.Append($"{firstLine}\n{secondLine}\n\n");
        }
            
        return song.Remove(song.Length - 2, 2).ToString();
    }

    private static string GetFirstLine(int bottles)
    {
        var numberOfBottles = $"{(bottles != 0 ? bottles.ToString() : "No more")}";
        var bottleWord = GetSingleOrPluralBottleForm(bottles);

        return $"{numberOfBottles} {bottleWord} of beer on the wall, {numberOfBottles.ToLower()} {bottleWord} of beer.";
    }

    private static string GetSecondLine(int bottles)
    {
        if (bottles == 0) return "Go to the store and buy some more, 99 bottles of beer on the wall.";

        var numberOfBottles = $"{(bottles == 1 ? "it" : "one")}";
        var bottlesLeft = $"{(bottles - 1 > 0 ? (bottles - 1).ToString() : "no more")}";
        var bottleWord = GetSingleOrPluralBottleForm(bottles - 1);

        return $"Take {numberOfBottles} down and pass it around, {bottlesLeft} {bottleWord} of beer on the wall.";
    }

    private static string GetSingleOrPluralBottleForm(int bottles)
        => $"bottle{(bottles == 1 ? string.Empty : "s")}";
}