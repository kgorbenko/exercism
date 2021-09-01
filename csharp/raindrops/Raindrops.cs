using System.Linq;

public static class Raindrops
{
    private static readonly (int Factor, string Sound)[] factorSounds = {
        ( 3, "Pling" ),
        ( 5, "Plang" ),
        ( 7, "Plong" )
    };

    public static string Convert(int number)
    {
        var applicableFactorSounds = factorSounds.Where(x => number % x.Factor == 0)
                                                 .ToArray();

        return applicableFactorSounds.Any()
            ? string.Join("", applicableFactorSounds.Select(x => x.Sound))
            : number.ToString();
    }
}