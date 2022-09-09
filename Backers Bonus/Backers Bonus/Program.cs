using System;

namespace Backers_Bonus
{
    using System.IO;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            // Reading backer names
            string backerNamesPath = "backers.txt";
            string[] backers = File.ReadAllLines(backerNamesPath);

            // Checking current player
            Console.WriteLine("State your name traveler.");
            Console.Write(">");
            string currentPlayer = Console.ReadLine();
            Console.WriteLine($"Welcome {currentPlayer}");

            if (backers.Contains(currentPlayer))
            {
                Console.WriteLine("You can access cool stuff");
            }
            else
            {
                Console.WriteLine("You can't access cool stuff");
            }
        }
    }
}
