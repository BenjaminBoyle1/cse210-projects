using System;
using System.Threading;

// Breathing Activity
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

protected override void PerformActivity(int duration)
{
    int cycles = duration / 10; // Calculate the number of cycles

    for (int i = 0; i < cycles; i++)
    {
        Console.WriteLine("Breathe in...");

        for (int countdown = 5; countdown >= 1; countdown--)
        {
            Console.Write($"{countdown}");
            Thread.Sleep(1000); // Pause for 1 second
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        Console.Write("    "); // Clear the final "1"
        Console.WriteLine();

        Console.WriteLine("Breathe out...");

        for (int countdown = 5; countdown >= 1; countdown--)
        {
            Console.Write($"{countdown}");
            Thread.Sleep(1000); // Pause for 1 second
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        Console.Write("    "); // Clear the final "1"
        Console.WriteLine();
    }
}
}
