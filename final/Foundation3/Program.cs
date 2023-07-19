// Program.cs
using System;

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
