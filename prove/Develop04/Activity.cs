using System;
using System.Threading;

// Base class for activities
public abstract class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }

    public void Start()
    {
        DisplayStartMessage();
        int duration = GetDuration();
        PrepareToBegin();
        PerformActivity(duration);
        DisplayEndMessage(duration);
    }

    protected void DisplayStartMessage()
    {
        Console.WriteLine($"\n{Name} Activity");
        Console.WriteLine(Description);
        Console.WriteLine("Please set the duration of the activity (in seconds).");
    }

    protected int GetDuration()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                return duration;
            else
                Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(4); // Display spinner for 3 seconds
    }

    protected abstract void PerformActivity(int duration);

    protected void DisplayEndMessage(int duration)
    {
        Console.WriteLine("Good job!");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine($"You have completed the {Name} Activity for {duration} seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    private void DisplaySpinner(int seconds)
{
    Console.CursorVisible = false;
    int delay = 250; // Delay between spinner frames in milliseconds
    string spinnerFrames = "/ - \\ |";
    int totalFrames = seconds * 1000 / delay; // Total number of frames to display

    for (int i = 0; i < totalFrames; i++)
    {
        int frameIndex = i % spinnerFrames.Length;
        Console.Write(spinnerFrames[frameIndex]);
        Thread.Sleep(delay);
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
    }

    Console.CursorVisible = true;
}


}
