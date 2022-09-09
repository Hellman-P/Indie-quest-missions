using System;

namespace More_monsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int[] monsterAmount = new int[100];

            Console.Write("Number of monsters in levels: ");
            for (int i = 0; i < 100; i++)
            {
                monsterAmount[i] = random.Next(1, 51);
            }
            Array.Sort(monsterAmount);
            Console.Write(string.Join(", ", monsterAmount));
            Console.WriteLine();
        }
    }
}
