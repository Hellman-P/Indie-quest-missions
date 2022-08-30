using System;
using System.Collections.Generic;
using System.Linq;

namespace _5th_Edition_stat_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables and such
            var random = new Random();
            var statOptions = new List<int> {};

            // Rolling and saving stats
            for (int global = 0; global < 6; global++)
            {
                int totalStat = 0;
                int currentRoll = 0;
                var stats = new List<int> {};

                for (int local = 0; local < 4; local++)
                {
                    currentRoll = random.Next(1, 7);
                    totalStat += currentRoll;
                    stats.Add(currentRoll);
                }

                // Converting stats list to string so it can be written nicely and writing it out
                List<string> statsString = stats.ConvertAll<string>(x => x.ToString());

                Console.Write("You rolled: ");
                Console.Write(String.Join(", ", statsString));

                // Removing lowest roll for correct total stat
                int lowest = stats.Min();
                totalStat -= lowest;
                stats.Remove(lowest);
                statOptions.Add(totalStat); // Adding total stat to statOptions list

                Console.WriteLine($" Your stat score is {totalStat}");
            }
            // Converting statOption list to string so it can be written nicely and writing it out
            List<string> statOptionString = statOptions.ConvertAll<string>(x => x.ToString());
            Console.WriteLine();
            Console.Write($"Your availible stat scores are: ");
            Console.WriteLine(String.Join(", ", statOptionString));
        }
    }
}
