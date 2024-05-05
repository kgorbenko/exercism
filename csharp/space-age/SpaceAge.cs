using System;

public class SpaceAge(int seconds)
{
    private const int EarthPeriod = 31557600;

    private double CalculateAge(double period) => Math.Round(seconds / (EarthPeriod * period), digits: 2);

    public double OnEarth() => CalculateAge(period: 1);

    public double OnMercury() => CalculateAge(period: 0.2408467);

    public double OnVenus() => CalculateAge(period: 0.61519726);

    public double OnMars() => CalculateAge(period: 1.8808158);

    public double OnJupiter() => CalculateAge(period: 11.862615);

    public double OnSaturn() => CalculateAge(period: 29.447498);

    public double OnUranus() => CalculateAge(period: 84.016846);

    public double OnNeptune() => CalculateAge(period: 164.79132);
}