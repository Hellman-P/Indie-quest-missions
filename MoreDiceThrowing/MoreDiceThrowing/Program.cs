using System;

namespace MoreDiceThrowing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int geloHP100 = 0;
            int geloHP1 = 0;
            int strength = 0;

            for (int str = 0; str < 3; str++)
            {
                strength += random.Next(1, 7);
            }

            Console.WriteLine("You roll 3d6 for your strength");
            Console.WriteLine($"Your strength score is: {strength}");

            for (int hp = 0; hp < 8; hp++)
            {
                geloHP1 += random.Next(1, 11);
            }
            geloHP1 += 40;

            Console.WriteLine($"A gelatinous cube with {geloHP1} HP appears!");

            for (int loop = 0; loop < 100; loop++)
            {
                for (int hp = 0; hp < 8; hp++)
                {
                    geloHP100 += random.Next(1, 11);
                }
                geloHP100 += 40;
            }
            Console.WriteLine($"An army of a 100 gelatinous cubes descent upon you with a total hp of {geloHP100}");
            Console.WriteLine("You eat the smallest ones first then increase dosage until you are immune");
        }

    }
}
