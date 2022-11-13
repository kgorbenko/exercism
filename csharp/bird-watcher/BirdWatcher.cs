using System.Linq;

public class BirdCount {
    private static readonly int[] lastWeekBirds = { 0, 2, 5, 3, 7, 8, 4 };
    private readonly int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1] += 1;
    }

    public static int[] LastWeek() =>
        lastWeekBirds;

    public int Today() =>
        birdsPerDay.Last();

    public bool HasDayWithoutBirds() =>
        birdsPerDay.Any(birdsCount => birdsCount == 0);

    public int CountForFirstDays(int numberOfDays) =>
        birdsPerDay.Take(numberOfDays)
                   .Sum();

    public int BusyDays() =>
        birdsPerDay.Count(birdsCount => birdsCount >= 5);
}