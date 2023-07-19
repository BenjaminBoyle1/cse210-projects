using System;

public class Swimming : Activity
{
    private int _laps;
    private const double _lapDistanceMeters = 50;
    private const double _metersToMiles = 0.000621371;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * _lapDistanceMeters * _metersToMiles;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (_minutes / 60.0);
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }
}
