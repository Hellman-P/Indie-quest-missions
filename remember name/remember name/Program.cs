using System;

namespace remember_name
{
    using System.IO;
    using System.Net.WebSockets;
    using System.Numerics;
    using System.Xml.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            string playerNamePath = "player-name.txt";

            if (File.Exists(playerNamePath))
            {
                string playerName = File.ReadAllText(playerNamePath);
                Console.WriteLine($"Welcome back to the shortest adventure of your life {playerName}.");
                Console.WriteLine("Cya next time...");
                File.Delete(playerNamePath);//added this so you can try different names
            }
            else
            {
                Console.WriteLine("Welcome to your shortest adventure yet!\n");
                Console.WriteLine("What is your name traveler?");
                Console.Write(">");
                string playerName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"I hope you're not expecting much {playerName}");
                File.WriteAllText(playerNamePath, playerName);
            }
        }
    }
}
