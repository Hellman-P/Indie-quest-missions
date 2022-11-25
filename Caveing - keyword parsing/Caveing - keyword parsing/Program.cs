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
            var CaveRooms = new List<CaveRoom>();

            CaveRooms.Add(new CaveRoom // 0
            {
                Description = "You enter a dark cave...",
                GenericKeywords = new SortedList<string, string>(),


                UniqueKeywords = new SortedList<string, string>(),
                AdjacenttRooms = new List<CaveRoom>()
            });
            CaveRooms.Add(new CaveRoom // 1
            {
                Description = "You enter a wet cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                AdjacenttRooms = new List<CaveRoom>()
            });
            CaveRooms.Add(new CaveRoom // 2
            {
                Description = "You enter a smelly cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                AdjacenttRooms = new List<CaveRoom>()
            });

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

            // Generating Rooms
            var CaveRooms = new List<CaveRoom>();
            CaveRoom currentRoom = new CaveRoom();
            GenerateRooms();

            //player input & calling methods
            while (true)
            {
                string playerInput = Console.ReadLine();

                keywordParser(room1Keywords, playerInput, 1);
            }
        }
    }
}
