// OutdoorGatheringEvent.cs
using System;

public class OutdoorGatheringEvent : Event
{
    private string _weather;

    public OutdoorGatheringEvent(string title, string description, DateTime date, TimeSpan time, Address address)
        : base(title, description, date, time, address)
    {
        // Assume the weather forecast is obtained from an API
        _weather = GetWeatherForecast();
    }

    public string GetWeather()
    {
        return _weather;
    }

    private string GetWeatherForecast()
    {
        // Code to retrieve weather forecast from an API goes here
        // For simplicity, let's assume it returns a hardcoded value
        return "Sunny";
    }

    public string GenerateFullMessage()
    {
        return $"{GenerateStandardMessage()}\nWeather: {_weather}";
    }

    public string GenerateShortDescription()
    {
        return $"Outdoor Gathering: {_title}\nDate: {_date:D}";
    }
}
