using System;
using System.Collections.Generic;
using System.Linq;

namespace basilisk_fights_back
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variables and such
            var random = new Random();
            var heroes = new List<string> { "Alucard", "Rudeus", "Canti", "Hoozuki" };
            var deadHeroes = new List<string> {};
            int basilHP = 0;
            int heroesLeft = 4;

            // Introducing the party
            Console.Write("The party of questionable warrios (");
            Console.Write(string.Join(", ", heroes));
            Console.WriteLine(") each weilding a 1d4 dagger descend upon the basilisk!");

            // Generating Basilisk
            for (int i = 0; i < 8; i++)
            {
                basilHP += random.Next(1, 9);
            }
            basilHP += 16;

            Console.WriteLine($"The basilisk with {basilHP} HP readies for battle!\n");

            // fighting the basilisk
            while (basilHP > 0 && heroesLeft > 0)
            {
                foreach (var hero in heroes)
                {
                    int damage = 0;

                    damage += random.Next(1, 5);
                    basilHP -= damage;

                    if (basilHP < 0)
                    {
                        basilHP = 0;
                    }
                    Console.WriteLine($"{hero} hits the basilisk for {damage} damage. The basilkisk has {basilHP} HP left.");
                    if (basilHP == 0)
                    {
                        break;
                    }
                }
                // the basilisk fighting back
                foreach (var hero in heroes)
                {
                    if (basilHP > 0)
                    {
                        int d20 = 0;
                        d20 = random.Next(1, 21);
                        int conSave = 5 + d20;

                        if (conSave < 12)
                        {
                            Console.WriteLine($"Sadly {hero} was a weakling and has been turned to stone permanetly");
                            deadHeroes.Add(hero);
                            heroesLeft -= 1;
                        }
                    }
                }
                foreach (var deadHero in deadHeroes)
                {
                    heroes.Remove(deadHero);
                }
            }
            Console.WriteLine();
            if (basilHP == 0)
            {
                Console.WriteLine("The questionable party managed to defeat the basilisk! Hoozaah!");
            }
            else
            {
                Console.WriteLine("The basilisk proved much to mighty and turned the entire party to stone");
            }

        }
    }
}
