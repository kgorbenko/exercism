public class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int minutes)
        => ExpectedMinutesInOven() - minutes;

    public int PreparationTimeInMinutes(int layers)
        => 2 * layers;

    public int ElapsedTimeInMinutes(int layers, int bakingTime)
        => PreparationTimeInMinutes(layers) + bakingTime;
}