using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the scriptures from the file
        ScriptureReader.LoadScriptures();

        // Get a random scripture
        string randomScripture = ScriptureReader.GetRandomScripture();

        if (!string.IsNullOrEmpty(randomScripture))
        {
            // Split the scripture into reference and text
            int index = randomScripture.IndexOf('-');
            if (index != -1)
            {
                string reference = randomScripture.Substring(0, index).Trim();
                string text = randomScripture.Substring(index + 1).Trim();

                // Create a scripture object
                Scripture scripture = new Scripture(reference, text);

                // Display the scripture
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press enter to continue or type 'quit' to end the program");

                string input = Console.ReadLine();

                while (input != "quit" && !scripture.AllWordsHidden())
                {
                    Console.Clear();
                    scripture.HideRandomWords(2);
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("Press enter to continue or type 'quit' to end the program");

                    input = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid scripture format.");
            }
        }
        else
        {
            Console.WriteLine("No scriptures found.");
        }
    }
}