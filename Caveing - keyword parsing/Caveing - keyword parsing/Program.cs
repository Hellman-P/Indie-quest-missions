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
            public SortedList<string, bool> ExplorationUnlocks = new SortedList<string, bool>();
        }
        static void uniqueKeywordUnlocks(string input, SortedList<string, string> uniqueKeywords)
        {
            // Add a way for unique keywords and combinations for unique keywords to change bool value in class to unlock possible neighboring room
        }


        static void keywordParser(string playerInput, SortedList<string, string> genericKeywords, SortedList<string, string> uniqueKeywords)
        {
            // Separating player input into list of strings
            string[] separatedPlayerInput =playerInput.Split(' ', ',', '.');

            // Comparing player inputs to all keywords
            foreach (string input in separatedPlayerInput)
            {
                // Comparing generic keywords
                foreach (KeyValuePair<string, string> keyValue in genericKeywords)
                {
                    if (keyValue.Key == input)
                        Console.WriteLine(keyValue.Value);
                }
                // Comparing unique keywords
                foreach (KeyValuePair<string, string> keyValue in uniqueKeywords)
                {
                    if (keyValue.Key == input)
                        uniqueKeywordUnlocks(input, uniqueKeywords);
                }
            }
        }


        static void Main(string[] args)
        {
            // Generating Rooms
            var caveRoomsList = new List<CaveRoom>();

            caveRoomsList.Add(new CaveRoom // 0
            {
                Description = "You enter a dark cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>()
            });
            caveRoomsList.Add(new CaveRoom // 1
            {
                Description = "You enter a wet cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>()
            });
            caveRoomsList.Add(new CaveRoom // 2
            {
                Description = "You enter a smelly cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>()
            });

            // Building room #1
            // Generic keywords
            caveRoomsList[0].GenericKeywords.Add("feel", "You feel around, feeling relatively smooth walls");
            caveRoomsList[0].GenericKeywords.Add("look", "You can't see anything");
            caveRoomsList[0].GenericKeywords.Add("smell", "You smell the air, theres nothing escpecially of note");
            caveRoomsList[0].GenericKeywords.Add("walk", "You walk around, you can hear your step echo far indicating a large space");
            caveRoomsList[0].GenericKeywords.Add("listen", "You can hear running water somewhere, sounds like alot");

            // Unique keywords
            caveRoomsList[0].UniqueKeywords.Add("pickaxe", "You feel a wooden handle, it fits comfortable in your hands. You lift the weight and feel it to make sure, it's an old pickaxe");
            caveRoomsList[0].UniqueKeywords.Add("Swim", " you consider jumping into the water for a while before carefully lowering yourself into the suprisingly deep cold stream. It's not as strong as you expected but you still have a hard time swimming");

            // Exploration unlocks
            caveRoomsList[0].GenericKeywords.Add("Tunnel", false); // why bool not work?


            // Building room #2
            caveRoomsList[1].GenericKeywords.Add("test", "testing");

            // Unique keywords

            // Exploration unlocks





            // Gameplay loop necessities
            int currentRoom = 1;
            var currentRoomGenericSortedList = caveRoomsList[currentRoom].GenericKeywords;
            var currentRoomUniqueSortedList = caveRoomsList[currentRoom].UniqueKeywords;

            //Gameplay loop
            while (true)
            {
                string playerInput = Console.ReadLine();
                // Put player input into lowercase and handle possible word variations
                keywordParser(playerInput, currentRoomGenericSortedList, currentRoomUniqueSortedList);
            }
        }
    }
}
