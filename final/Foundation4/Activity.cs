using System;

public abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min) - " +
                         $"Distance: {distance:F2} miles, Speed: {speed:F2} mph, Pace: {pace:F2} min/mile";
        return summary;
    }
}
