using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Caveing___keyword_parsing
{
    internal class Program
    {
        static void uniqueKeywordUnlocks(string uniqueKeyword, int roomNumber)
        {
            switch (roomNumber)
            {
                case 1:
                    switch (uniqueKeyword)
                    {
                        case "rope":
                            Console.WriteLine("You remember falling from a breaking rope, maybe you can still climb it");

                            break;

                        case "swim":
                            Console.WriteLine("There might be an underwater passage, I wont know until I try");

                            break;

                        default:
                            Console.WriteLine("ERROR");
                            break;
                    }
                    break;

                case 2:
                    switch (uniqueKeyword)
                    {

                    }
                    break;

                case 3:
                    switch (uniqueKeyword)
                    {

                    }
                    break;

                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
        static void keywordParser(List<string> uniqueKeywords, string playerInput, int roomNummer)
        {
            // Separating player input into list of strings
            string[] separatedPlayerInput =playerInput.Split(' ');

            var genericKeywords = new List<string> { "look", "feel", "smell"};

            // Comparing player inputs to all keywords
            foreach (string input in separatedPlayerInput)
            {
                // Comparing generic keywords
                foreach (string keyword in genericKeywords)
                { 
                    if (input == keyword)
                    {
                        switch (input)
                        {
                            case "look":
                                Console.WriteLine("It's dark, You can't see anything");
                                break;

                            case "feel":
                                Console.WriteLine("You feel rocks, you are in a cave... Probably");
                                break;

                            case "smell":
                                Console.WriteLine("Smells like... Cave...");
                                break;

                                default:
                                break;
                        }
                    }
                }
                // Comparing unique keywords
                foreach (string keyword in uniqueKeywords)
                {
                    if (input == keyword)
                    {
                        uniqueKeywordUnlocks(input, roomNummer);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // Room Data
            // Room 1
            var room1Keywords = new List<string> { "rope", "swim"};
            bool rope = false;
            bool swim = false;
            // Room 2
            var room2Keywords = new List<string> { };

            // Room 3
            var room3Keywords = new List<string> { };


            //player input & calling methods
            while (true)
            {
                string playerInput = Console.ReadLine();

                keywordParser(room1Keywords, playerInput, 1);
            }
        }
    }
}
