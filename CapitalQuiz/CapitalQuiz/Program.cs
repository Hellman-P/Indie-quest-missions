using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

namespace Olympic_Games_quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var scoreKeep = new SortedList<string, int>();

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
                    Console.Write("Who answered? ");
                    string answerName = Console.ReadLine();
                    if (scoreKeep.ContainsKey(answerName))
                    {
                        scoreKeep[answerName]++;
                    }
                    else
                    {
                        scoreKeep.Add(answerName, 1);
                    }
                    Console.WriteLine("You gained a point!\n");
                    Console.WriteLine("PRESS ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Incorrect! the capital of {capitalCities.Keys[countryIndex]} is {capitalCities.Values[countryIndex]}\n");
                    Console.WriteLine("PRESS ENTER to continue...");
                    Console.ReadLine();
                }

                var sortedPlayersKeys = scoreKeep.Keys.OrderBy((player) => scoreKeep[player]).Reverse().ToList();

                Console.WriteLine("Current scores are:\n");
                for (int i = 0; i < scoreKeep.Count; i++)
                { 
                    Console.WriteLine($"{i + 1}. {sortedPlayersKeys[i]} {scoreKeep[sortedPlayersKeys[i]]}");

                    //Console.WriteLine($"{i+1}. {scoreKeep.Keys[i]} {scoreKeep.Values[i]}");
                }
                Console.WriteLine();
                Console.WriteLine("PRESS ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
