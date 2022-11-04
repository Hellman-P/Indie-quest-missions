using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace Olympic_Games_quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var capitalCities = new SortedList<string, string>();
            capitalCities["Netherlands"] = "Amsterdam";
            capitalCities["Greece"] = "Athens";
            capitalCities["Egypt"] = "Cairo";
            capitalCities["Denmark"] = "Copenhagen";
            capitalCities["Finland"] = "Helsinki";

            while (true)
            {
                int countryIndex = random.Next(capitalCities.Count);

                Console.WriteLine($"What is the capital of {capitalCities.Keys[countryIndex]}");

                string guessedCapital = Console.ReadLine();

                if (guessedCapital == capitalCities.Values[countryIndex])
                {
                    Console.WriteLine("Correct!\n");
                    Console.WriteLine("PRESS ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Incorrect! the capital of {capitalCities.Keys[countryIndex]} is {capitalCities.Values[countryIndex]}\n");
                    Console.WriteLine("PRESS ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
