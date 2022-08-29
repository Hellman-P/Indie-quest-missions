using System;

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
            int shells = 5;

            string Distance = new string('_', tankDistance);
            string remainingDistance = new string('_', distanceRemain);

            // Enter Name
            Console.Write("State you name Commander: ");
            string commander = Console.ReadLine();
            Console.WriteLine($"Your name is {commander}? lol\n\n");

            // Drawing Map
            Console.WriteLine("Here is a map of the battlefield:\n");
            Console.Write("_/");
            Console.Write(Distance);
            Console.Write("T");
            Console.WriteLine(remainingDistance + "\n");

            // Aiming & Shooting
            while (shells > 0)
            {
                Console.WriteLine($"Aim your shot commander {commander}! You have {shells} shells left");
                Console.Write("Enter Distance: ");
                int aim = Convert.ToInt32(Console.ReadLine());
                string aimResult = new string(' ', aim);
                shells --;

                Console.Write(aimResult + "  ");
                Console.WriteLine("*");

                // Results
                if (tankDistance == aim)
                {
                    Console.WriteLine($"Congratulations Commander {commander} you did it!\n");
                    shells = 0;
                }
                if (tankDistance < aim)
                {
                    Console.Write("Oh no you aimed too high! ");
                    if (shells == 0)
                        Console.WriteLine("We're doomed!\n");
                }
                if (tankDistance > aim)
                {
                    Console.Write("Oh no you aimed too low!");
                    if (shells == 0)
                        Console.WriteLine("We're doomed!\n");
                }

                    
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
