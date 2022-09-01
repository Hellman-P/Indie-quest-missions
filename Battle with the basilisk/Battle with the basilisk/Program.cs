using System;
using System.Collections.Generic;

namespace Battle_with_the_basilisk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables and such
            var random = new Random();
            var heroes = new List<string> {"Alucard", "Rudeus", "Canti", "Hoozuki" };
            int basilHP = 0;

            // Introducing the party
            Console.Write("The party of questionable warrios (");
            Console.Write(string.Join(", ",heroes));
            Console.WriteLine(") each weilding a 2d6 greatsword descend upon the basilisk!");

            // Generating Basilisk
            for (int i = 0; i < 8; i++)
            {
                basilHP += random.Next(1, 9);
            }
            basilHP += 16;

            Console.WriteLine($"The basilisk with {basilHP} HP readies for battle!\n");

            // Killing the basilisk
            while (basilHP >0)
            {
                foreach (var hero in heroes)
                {
                    int damage = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        damage += random.Next(1, 7);
                    }
                    basilHP -= damage;
                    if (basilHP < 0)
                    {
                        basilHP = 0;
                    }
                    Console.Write(hero);
                    Console.WriteLine($"{hero} hits the basilisk for {damage} damage. The basilkisk has {basilHP} HP left.");
                    if (basilHP == 0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("The questionable party managed to defeat the basilisk! Hoozaah!");

        }
    }
}
