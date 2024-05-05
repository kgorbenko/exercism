using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup(int month, int year)
{
    private static readonly ImmutableHashSet<int> teensDaysNumbers =
        ImmutableHashSet.Create(
            13, 14, 15, 16, 17, 18, 19
        );

    private IEnumerable<DateTime> Days(DayOfWeek dayOfWeek) =>
        Enumerable
            .Range(1, DateTime.DaysInMonth(year: year, month: month))
            .Select(x => new DateTime(year: year, month: month, day: x))
            .Where(x => x.DayOfWeek == dayOfWeek);

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule) =>
        schedule switch
        {
            Schedule.Teenth => Days(dayOfWeek).Single(x => teensDaysNumbers.Contains(x.Day)),
            Schedule.First => Days(dayOfWeek).ElementAt(0),
            Schedule.Second => Days(dayOfWeek).ElementAt(1),
            Schedule.Third => Days(dayOfWeek).ElementAt(2),
            Schedule.Fourth => Days(dayOfWeek).ElementAt(3),
            Schedule.Last => Days(dayOfWeek).Last(),
            _ => throw new ArgumentOutOfRangeException(nameof(schedule))
        };
}