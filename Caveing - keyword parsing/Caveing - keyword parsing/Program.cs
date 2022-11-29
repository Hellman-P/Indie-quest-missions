using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;

namespace Caveing___keyword_parsing
{
    internal class Program
    {
        class CaveRoom
        {
            public string Description;
            public SortedList<string, string> GenericKeywords = new SortedList<string, string>();
            public SortedList<string, string> UniqueKeywords = new SortedList<string, string>();
            public List<CaveRoom> AdjacenttRooms = new List<CaveRoom>();
        }


        static void GenerateRooms()
        {
            var caveRoomsList = new List<CaveRoom>();

            caveRoomsList.Add(new CaveRoom // 0
            {
                Description = "You enter a dark cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                AdjacenttRooms = new List<CaveRoom>()
            });
            caveRoomsList.Add(new CaveRoom // 1
            {
                Description = "You enter a wet cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                AdjacenttRooms = new List<CaveRoom>()
            });
            caveRoomsList.Add(new CaveRoom // 2
            {
                Description = "You enter a smelly cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                AdjacenttRooms = new List<CaveRoom>()
            });

            // Room 1 generic keywords
            caveRoomsList[0].GenericKeywords.Add("feel", "You feel around, feeling relatively smooth walls");
            caveRoomsList[0].GenericKeywords.Add("look", "You can't see anything");
            caveRoomsList[0].GenericKeywords.Add("smell", "You smell the air, theres nothing escpecially of note");
            caveRoomsList[0].GenericKeywords.Add("walk", "you walk around, you can hear your step echo far indicating a large space");
        }


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


        static void keywordParser(string playerInput)
        {
            // Separating player input into list of strings
            string[] separatedPlayerInput =playerInput.Split(' ');

            var genericKeywords = ;
            var uniqueKeywords = "filler";

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
                        uniqueKeywordUnlocks(input);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            GenerateRooms();

            //Gameplay
            while (true)
            {
                string playerInput = Console.ReadLine();
                // Put player input into lowercase and handle possible word variations
                keywordParser(playerInput);
            }
        }
    }
}
