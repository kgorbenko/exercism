using System;

public static class AssemblyLine
{
    private const int CarsPerHour = 221;

    public static double ProductionRatePerHour(int speed)
        => CarsPerHour * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed)
        => (int) ProductionRatePerHour(speed) / 60;

    public static double SuccessRate(int speed)
    {
        return speed switch {
            0    => 0,
            <= 4 => 1,
            <= 8 => 0.9,
            9    => 0.8,
            10   => 0.77,
            _    => throw new ArgumentOutOfRangeException(nameof(speed))
        };
    }
}