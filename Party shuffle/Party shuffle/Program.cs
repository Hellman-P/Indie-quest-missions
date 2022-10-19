using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Party_shuffle
{
    internal class Program
    {
        static void ShuffleList(List<string> gamers)
        {
            Random random = new Random();

            var shuffled = new List<string> {};
            var gamersCopy = new List<string>(gamers);


            for (int i = 0; i < gamers.Count; i++)
            {
                int randomIndex = random.Next(gamersCopy.Count);
                shuffled.Add(gamersCopy[randomIndex]);
                gamersCopy.Remove(gamersCopy[randomIndex]);
            }

            Console.WriteLine($"Order of scrubs in this session are: {string.Join(", ", shuffled)} ");
        }
        static void Main(string[] args)
        {
            var gamers = new List<string> { "Allie", "Ben", "Claire", "Dan", "Eleanor" };

            Console.WriteLine($"Gamers in this session are: {string.Join(", ", gamers)} \n");
            Console.WriteLine("Generating random order of scrubs....\n");

            ShuffleList(gamers);

        }
    }
}
