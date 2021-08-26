public struct Clock
{
    private const int MinutesInHour = 60;
    private const int HoursInDay = 24;
    private const int MinutesInDay = MinutesInHour * HoursInDay;

    public int Hours { get; }

    public int Minutes { get; }

    public Clock(int hours, int minutes)
    {
        var totalMinutes    = minutes + hours * MinutesInHour;
        var positiveMinutes = (totalMinutes % MinutesInDay + MinutesInDay) % MinutesInDay;

        Hours   = positiveMinutes / MinutesInHour;
        Minutes = positiveMinutes % MinutesInHour;
    }

    public Clock Add(int minutesToAdd)
        => new Clock(Hours, Minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract)
        => new Clock(Hours, Minutes - minutesToSubtract);

    public override string ToString() => $"{Hours:00}:{Minutes:00}";
}