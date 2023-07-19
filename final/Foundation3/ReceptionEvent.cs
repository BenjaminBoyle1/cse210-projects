// ReceptionEvent.cs
using System;

public class ReceptionEvent : Event
{
    private string _rsvpEmail;

    public ReceptionEvent(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public string GetRSVPEmail()
    {
        return _rsvpEmail;
    }

    public string GenerateFullMessage()
    {
        return $"{GenerateStandardMessage()}\nRSVP Email: {_rsvpEmail}";
    }

    public string GenerateShortDescription()
    {
        return $"Reception: {_title}\nDate: {_date:D}";
    }
}
