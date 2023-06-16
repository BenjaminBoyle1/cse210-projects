using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (choice == 1)
            {
                string prompt = promptGenerator.GeneratePrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Response: ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString();

                journal.AddEntry(prompt, response, date);
            }
            else if (choice == 2)
            {
                journal.DisplayEntries();
            }
            else if (choice == 3)
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == 5)
            {
                break;
            }

            Console.WriteLine();
        }
    }
}
