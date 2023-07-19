// LectureEvent.cs
using System;

public class LectureEvent : Event
{
    private string _speaker;
    private int _capacity;

    public LectureEvent(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string GetSpeaker()
    {
        return _speaker;
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public string GenerateFullMessage()
    {
        return $"{GenerateStandardMessage()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }

    public string GenerateShortDescription()
    {
        return $"Lecture: {_title}\nDate: {_date:D}";
    }
}
