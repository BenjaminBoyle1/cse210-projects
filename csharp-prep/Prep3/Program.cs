using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain)
        { 
            Random randomGenerator = new Random();
            int magic = randomGenerator.Next(1, 101);
        
            int guess = 0;

            int numGuesses = 0;

        
            while (guess != magic)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numGuesses ++;
            
                if (magic < guess)
                {
                    Console.WriteLine("Lower");
                }
            
                else if (magic > guess)
                {
                    Console.WriteLine("Higher");
                }
            
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }   
            Console.WriteLine($"You guessed the magic number in {numGuesses}");
            Console.Write("Do you want to play again? (yes/no) ");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = (playAgainInput == "yes"|| playAgainInput == "y"); 
        }    
    }
}