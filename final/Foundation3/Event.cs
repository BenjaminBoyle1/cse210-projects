// Event.cs
using System;

public class Event
{
    protected string _title;
    protected string _description;
    protected DateTime _date;
    protected TimeSpan _time;
    protected Address _address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetDescription()
    {
        return _description;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public TimeSpan GetTime()
    {
        return _time;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public string GenerateStandardMessage()
    {
        return $"Event: {_title}\nDescription: {_description}\nDate: {_date:D}\nTime: {_time:hh\\:mm}\nAddress: {_address.GetFullAddress()}";
    }
}
