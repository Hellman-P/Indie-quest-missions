using System;

namespace HealSpell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int health = random.Next (0, 101);

            Console.WriteLine($"Warrior Health is : {health}");
            Console.WriteLine("the heal Spell is cast!");

            if (health < 50)
            {

                while (health < 50)
                {
                    health += 10;
                    Console.WriteLine($"Warrior health: {health}");
                }
                Console.WriteLine("The spell has concluded");
            }
            else
            {
                Console.WriteLine("The spell has concluded");
            }
        }
    }
}

