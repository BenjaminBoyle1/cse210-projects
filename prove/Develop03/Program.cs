using System;

class Program
{
    static void Main(string[] args)
{
    // Load the scriptures from the file
    ScriptureReader.LoadScriptures();

    // Get a random scripture
    string randomScripture = ScriptureReader.GetRandomScripture();

    // Split the scripture into reference and text
    string[] scriptureParts = randomScripture.Split('-');
    if (scriptureParts.Length >= 2)
    {
        string referenceText = scriptureParts[0].Trim();
        string scriptureText = string.Join("-", scriptureParts.Skip(1)).Trim();

        // Create scripture and display it
        Reference reference = new Reference(referenceText);
        Scripture scripture = new Scripture(reference, scriptureText);

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
}
