using System;

namespace BowlingScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int knock1 = random.Next(0, 11);
            if (knock1 == 10)
            {
                Console.WriteLine("First Throw: X");
                Console.WriteLine("Knocked Pins: 10");
            }
            else
            {
                Console.WriteLine($"First throw: {knock1}");

                int remain = 10 - knock1;
                int knock2 = random.Next(0, remain+1);
                if (knock2 == remain)
                {
                    Console.WriteLine("Second Throw: /");
                    Console.WriteLine("Knocked Pins: 10");
                }
                else
                {
                    int total = knock1 + knock2;
                    Console.WriteLine($"Second throw: {knock2}");
                    Console.WriteLine($"Knocked Pins: {total}");

                }
            }
        }
    }
}
