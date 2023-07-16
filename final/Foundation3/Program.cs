using System;

class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetDescription()
    {
        return description;
    }

    public DateTime GetDate()
    {
        return date;
    }

    public TimeSpan GetTime()
    {
        return time;
    }

    public Address GetAddress()
    {
        return address;
    }

    public string GenerateStandardMessage()
    {
        return $"Event: {GetTitle()}\nDescription: {GetDescription()}\nDate: {GetDate():D}\nTime: {GetTime():hh\\:mm}\nAddress: {GetAddress().GetFullAddress()}";
    }
}

class LectureEvent : Event
{
    private string speaker;
    private int capacity;

    public LectureEvent(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public string GetSpeaker()
    {
        return speaker;
    }

    public int GetCapacity()
    {
        return capacity;
    }

    public string GenerateFullMessage()
    {
        return $"{GenerateStandardMessage()}\nSpeaker: {GetSpeaker()}\nCapacity: {GetCapacity()}";
    }

    public string GenerateShortDescription()
    {
        return $"Lecture: {GetTitle()}\nDate: {GetDate():D}";
    }
}

class ReceptionEvent : Event
{
    private string rsvpEmail;

    public ReceptionEvent(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public string GetRSVPEmail()
    {
        return rsvpEmail;
    }

    public string GenerateFullMessage()
    {
        return $"{GenerateStandardMessage()}\nRSVP Email: {GetRSVPEmail()}";
    }

    public string GenerateShortDescription()
    {
        return $"Reception: {GetTitle()}\nDate: {GetDate():D}";
    }
}

class OutdoorGatheringEvent : Event
{
    private string weather;

    public OutdoorGatheringEvent(string title, string description, DateTime date, TimeSpan time, Address address)
        : base(title, description, date, time, address)
    {
        this.weather = GetWeatherForecast();
    }

    public string GetWeather()
    {
        return weather;
    }

    private string GetWeatherForecast()
    {
        return "Sunny";
    }

    public string GenerateFullMessage()
    {
        return $"{GenerateStandardMessage()}\nWeather: {GetWeather()}";
    }

    public string GenerateShortDescription()
    {
        return $"Outdoor Gathering: {GetTitle()}\nDate: {GetDate():D}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("123 Main St", "City", "State", "12345");

        LectureEvent lectureEvent = new LectureEvent("Lecture Title", "Lecture Description", DateTime.Now, TimeSpan.FromHours(2), address, "John Doe", 100);
        Console.WriteLine("=== Lecture Event ===");
        Console.WriteLine(lectureEvent.GenerateStandardMessage());
        Console.WriteLine();

        ReceptionEvent receptionEvent = new ReceptionEvent("Reception Title", "Reception Description", DateTime.Now, TimeSpan.FromHours(3), address, "rsvp@example.com");
        Console.WriteLine("=== Reception Event ===");
        Console.WriteLine(receptionEvent.GenerateStandardMessage());
        Console.WriteLine();

        OutdoorGatheringEvent outdoorEvent = new OutdoorGatheringEvent("Outdoor Event Title", "Outdoor Event Description", DateTime.Now, TimeSpan.FromHours(4), address);
        Console.WriteLine("=== Outdoor Gathering Event ===");
        Console.WriteLine(outdoorEvent.GenerateStandardMessage());
        Console.WriteLine();
    }
}
