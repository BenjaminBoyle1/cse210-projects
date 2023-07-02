using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

   protected override void PerformActivity(int duration)
{
    Random random = new Random();
    int promptIndex = random.Next(prompts.Length);
    string prompt = prompts[promptIndex];

    Console.WriteLine($"\nPrompt: {prompt}");
    Console.WriteLine("When you have something in mind, press Enter to continue.");
    Console.ReadLine(); // Wait for user to press Enter

    Console.Clear();
    Thread.Sleep(3000); // Wait for 3 seconds

    bool exitEarly = false;

    for (int i = 0; i < duration; i++)
    {
        Console.Clear();

        Console.WriteLine($"Prompt: {prompt}");

        int questionCount = 0;
        while (questionCount < 2)
        {
            Console.WriteLine();
            int questionIndex = random.Next(questions.Length);
            string question = questions[questionIndex];

            Console.WriteLine($"Question: {question}");

            DisplaySpinner(5); // Display spinner for 5 seconds

            questionCount++;
        }

        Console.Clear();

        if (i < duration - 1)
        {
            Console.WriteLine("Press Enter to continue or type 'exit' to return to the menu.");
            string input = Console.ReadLine(); // Read user input

            if (input.ToLower() == "exit")
            {
                exitEarly = true;
                break; // Exit the for loop
            }
        }
        else
        {
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine(); // Wait for user to press Enter
        }
    }

    if (exitEarly)
    {
        Console.WriteLine("You have chosen to exit the activity early. Returning to the menu...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}




    private void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(400);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(400);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(400);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(400);
            Console.Write("\b");
        }
    }
}
