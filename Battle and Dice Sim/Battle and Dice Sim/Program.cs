using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Battle_and_Dice_Sim
{
    internal class Program
    {
        static Random random = new Random();

        static void SimulateBattle(List<string> heroes, string monsterName, int monsterHP, int savingThrowDC, int introTrigger)
        {
            if (heroes.Count == 0)
            {
                return;
            }

            // Introducing the party for first combat
            if (introTrigger == 0)
            {
                Console.Write("A party of questionable warrios (");
                Console.Write(string.Join(", ", heroes));
                Console.WriteLine($") each weilding a 2d6 greatsword descend into a dungeon...");
                Console.WriteLine($"Suddenly a {monsterName} with {monsterHP} HP appears looking for battle!\n");
            }
            // additional monster introductions
            else if (introTrigger == 1)
            {
                Console.WriteLine($"From nowhere a {monsterName} conjures a door next to the party looking for a fight\n");
            }
            else if (introTrigger == 2)
            {
                Console.WriteLine($"The ground shakes as a huge {monsterName} enters the room ducking to get through the door\n");
            }
            else // I know this doesn't do anything just for completions sake incase I wanted a generic intro
            {
                Console.WriteLine($"Altough a {monsterName} also suddenly appears! The party once again readies for battle!\n");
            }
            // fighting the monsters
            while (monsterHP > 0 && heroes.Count > 0)
            {
                foreach (var hero in heroes)
                {
                    int damage = DiceRoll(numberOfRolls: 2, diceSides: 6); // Rolling 2d6 greatsword damage
                    monsterHP -= damage;

                    if (monsterHP < 0)
                    {
                        monsterHP = 0;
                    }
                    Console.WriteLine($"{hero} hits the {monsterName} for {damage} damage. The {monsterName} has {monsterHP} HP left.");
                    if (monsterHP == 0)
                    {
                        break;
                    }
                }
                // the monsters fighting back
                if (monsterHP > 0)
                {
                    int enemyTargetIndex = random.Next(heroes.Count);
                    string enemyTarget = heroes[enemyTargetIndex];

                    int saveDC = DiceRoll(numberOfRolls: 1, diceSides: 20, fixedBonus: 5); // savingthrow

                    Console.WriteLine();
                    if (saveDC < savingThrowDC)
                    {
                        Console.WriteLine($"Sadly {enemyTarget} was a weakling and has been killed by the {monsterName}\n");
                        heroes.Remove(enemyTarget);
                    }
                    else
                    {
                        Console.WriteLine($"The {monsterName} attacks but misses\n");
                    }

                }
            }
            //Ending speech
            Console.WriteLine();
            if (monsterHP == 0)
            {
                Console.WriteLine($"The questionable party managed to defeat the {monsterName}! Hoozaah!");
            }
            else
            {
                Console.WriteLine($"The {monsterName} proved much to mighty and killed the entire party");
            }
        }
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int diceResult = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                diceResult += random.Next(1, diceSides + 1);
            }
            return diceResult + fixedBonus;
        }
        static void Main(string[] args)
        {
            // List of heroes
            var heroes = new List<string> { "Alucard", "Rudeus", "Canti", "Hoosuki" };

            int orcHP = DiceRoll(numberOfRolls: 2, diceSides: 8, fixedBonus: 6); // Rolling orc health
            SimulateBattle(heroes: heroes, monsterName: "orc", monsterHP: orcHP, savingThrowDC: 12, introTrigger: 0);
            int mageHP = DiceRoll(numberOfRolls: 9, diceSides: 8); // Rolling mage health
            SimulateBattle(heroes: heroes, monsterName: "mage", monsterHP: mageHP, savingThrowDC: 20, introTrigger: 1);
            int trollHP = DiceRoll(numberOfRolls: 8, diceSides: 10, fixedBonus: 40); // Rolling troll health
            SimulateBattle(heroes: heroes, monsterName: "troll", monsterHP: trollHP, savingThrowDC: 18, introTrigger: 2);

            if (heroes.Count == 4)
            {
                Console.WriteLine("All the heroes sadly made it, horay...");
            }
            else if (heroes.Count > 0)
            {
                Console.WriteLine($"The party managed to get through the dungeon. altough only {string.Join(", ", heroes)} managed to survive");
            }
        }
    }
}

