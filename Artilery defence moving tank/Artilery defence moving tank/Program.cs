using System;
using System.Linq.Expressions;
using System.Runtime;

namespace ArtilleryDefence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DANGER! A tank is rapidly aproaching your position. it should be in range of your artilery.\n");

            var random = new Random();

            int tankDistance = random.Next(40, 71);
            int distanceRemain = 77 - tankDistance;
            int winner = 0;

            // Enter Name
            Console.Write("State you name Commander: ");
            string commander = Console.ReadLine();
            Console.WriteLine($"Your name is {commander}? lol\n");

            Console.WriteLine("Press ENTER to accept your name and see the combat map...");
            ConsoleKeyInfo acceptName = Console.ReadKey(true);
            if (acceptName.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }

            // Gameplay Loop
            while (winner < 1 && tankDistance > 0)
            {

                // Drawing Map
                string Distance = new string('_', tankDistance);
                string remainingDistance = new string('_', distanceRemain);
                Console.WriteLine("Here is a map of the battlefield:\n");
                Console.Write("_/");
                Console.Write(Distance);
                Console.Write("T");
                Console.WriteLine(remainingDistance + "\n");

                // Aiming
                Console.WriteLine($"Aim your shot commander {commander}!");
                Console.Write("Enter Distance: ");
                int aim = Convert.ToInt32(Console.ReadLine());
                string aimResult = new string(' ', aim);

                Console.Write(aimResult + "  ");
                Console.WriteLine("*");

                // Results
                if (tankDistance < aim)
                {
                    Console.WriteLine("Oh no you aimed too high! ");
                }
                if (tankDistance > aim)
                {
                    Console.WriteLine("Oh no you aimed too low!");
                }
                if (tankDistance == aim)
                {
                    Console.WriteLine($"Congratulations Commander {commander} you did it!\n");
                    Console.WriteLine("Press ENTER to continue...");
                    ConsoleKeyInfo reload = Console.ReadKey(true);
                    if (reload.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                    }
                    winner += 1;
                }
                else
                {
                    Console.WriteLine("Press ENTER to reload your artilery...");
                    ConsoleKeyInfo reload = Console.ReadKey(true);
                    if (reload.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                    }
                }
                // Moving tank & updating map
                int movingPosition = random.Next(1,16);
                tankDistance -= movingPosition;
                distanceRemain += movingPosition;

            }
            // Ending sequence
            if (tankDistance < 1)
            {
                Console.WriteLine("Your incompetence has doomed all your men and yourself.\n");
            }
            else
            {
                Console.WriteLine("Your truly great skills have saved you and your men!\n");
            }
            Console.WriteLine("......");

        }
    }
}
