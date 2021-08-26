using System;

public struct Clock
{
    private int hours;
    private int minutes;

    public Clock(int hours, int minutes)
    {
        this.hours = hours + minutes / 60;
        while (this.hours >= 24 || this.hours < 0)
            this.hours -= Math.Sign(this.hours)*24;

        this.minutes = minutes % 60;
        while (this.minutes < 0)
            { this.minutes += 60; this.hours--; }
    }

    public int Hours
    {
        get { return hours; }
    }

    public int Minutes
    {
        get { return minutes; }
    }

    public Clock Add(int minutesToAdd)
    {
        if (minutesToAdd < 0) return Subtract(-minutesToAdd);

        hours += (minutes + minutesToAdd) / 60;
        minutes = (minutes + minutesToAdd) % 60;

        while (hours >= 24) hours -= 24;
        return new Clock(hours, minutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        if (minutesToSubtract < 0) return Add(-minutesToSubtract);

        minutesToSubtract -= minutes; minutes = 0;
        hours -=  minutesToSubtract / 60 + 1;
        minutes = 60 - (minutesToSubtract % 60);

        while (hours < 0) hours += 24;
        return new Clock(hours, minutes);
    }

    public override string ToString()
    {
        string hour = "00", minute = "00";

        if (hours < 10) hour = $"0{hours.ToString()}";
        else hour = hours.ToString();

        if (minutes < 10) minute = $"0{minutes.ToString()}";
        else minute = minutes.ToString();

        return hour + ':' + minute; 
    }
}