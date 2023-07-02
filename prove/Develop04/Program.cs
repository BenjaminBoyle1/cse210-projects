class MainProgram
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Activity breathingActivity = new BreathingActivity();
                breathingActivity.Start();
            }
            else if (input == "2")
            {
                Activity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Start();
            }
            else if (input == "3")
            {
                Activity listingActivity = new ListingActivity();
                listingActivity.Start();
            }
            else if (input == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine();
        }
    }
}
