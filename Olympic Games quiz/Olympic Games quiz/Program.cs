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

            var hostCountries = new Dictionary<int, string>();
            hostCountries[2022] = "China";
            hostCountries[2020] = "Japan";
            hostCountries[2018] = "South Korea";
            hostCountries[2016] = "Brazil";
            hostCountries[2014] = "Russia";
            hostCountries[2012] = "United Kingdom";
            hostCountries[2010] = "Canada";
            hostCountries[2008] = "China";
            hostCountries[2006] = "Italy";
            hostCountries[2004] = "Greece";
            hostCountries[2002] = "United States";
            hostCountries[2000] = "Australia";

            while (true)
            {
                int year = 2000 + random.Next(hostCountries.Count) * 2;

                Console.WriteLine($"What Country hosted the Olympics in the year: {year}");

                string guessedCountry = Console.ReadLine();

                if (guessedCountry == hostCountries[year])
                {
                    Console.WriteLine("Correct!\n");
                    Console.WriteLine("PRESS ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Incorrect! The country who hosted the Olympics during {year} was {hostCountries[year]}\n");
                    Console.WriteLine("PRESS ENTER to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
