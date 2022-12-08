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
            public SortedList<List<string>, bool> PossiblePaths = new SortedList<List<string>, bool>();
        }
        static void uniqueKeywordUnlocks(string input, SortedList<string, string> uniqueKeywords, SortedList<string, bool> unlocks)
        {
            // Writing unique keyword text and also unlocking exploration keys
            Console.WriteLine(uniqueKeywords[input]);
            unlocks[input] = true;
        }


        static void roomExitManager(SortedList<List<string>, bool> possiblePaths, SortedList<string, bool> unlocks)
        {
            Console.WriteLine("I could consider moving forwards, maybe I should?");

            // Separating player input into list of strings
            string playerInput = Console.ReadLine();
            string playerInputLower = playerInput.ToLower();
            string[] separatedPlayerInput = playerInputLower.Split(' ', ',', '.');

            // Checking of the player wants to move to another room
            foreach (string input in separatedPlayerInput)
            switch (input)
            {
                case "yes": case "y":
                        // Checking what options the player has unlocked and showing what they can do

                        // Putting true keywords in list
                        var foundKeywords = new List<string>();
                        foreach (KeyValuePair<string, bool> keyValue in unlocks)
                        {
                            if (keyValue.Value == true)
                                foundKeywords.Add(keyValue.Key);
                        }

                        // Comparing each possible paths keywords with found keywords
                        foreach (KeyValuePair<List<string>, bool> keyValue in possiblePaths)
                        {
                            bool b = true;
                            foreach (string pathTrígger in keyValue.Key)
                            {
                                if (!foundKeywords.Contains(pathTrígger))
                                {
                                    b = false;
                                        break;

                                }
                            }
                            if (b == true)
                            {
                                possiblePaths[keyValue.Key] = true;
                            }
                        }




                        break;

               case "no": case "n":
                    Console.WriteLine("Not now, I need to explore more");
                    break;

                default:
                        Console.WriteLine("I'll consider it later...");
                    break;
            }
        }


        static void keywordParser(string playerInput, SortedList<string, string> genericKeywords, SortedList<string, string> uniqueKeywords, SortedList<string, bool> unlocks, SortedList<List<string>, bool> possiblePaths)
        {
            // Separating player input into list of strings
            string[] separatedPlayerInput =playerInput.Split(' ',',','.');

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
                        uniqueKeywordUnlocks(input, uniqueKeywords, unlocks);
                }

                switch(input)
                {
                    // Checking if player wants to leave
                    case "leave": case "exit":
                        roomExitManager(possiblePaths, unlocks);
                        break;

                    default:
                        break;
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
                ExplorationUnlocks = new SortedList<string, bool>(),
                PossiblePaths = new SortedList<List<string>, bool>()
            });
            caveRoomsList.Add(new CaveRoom // 1
            {
                Description = "You enter a wet cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>(),
                PossiblePaths = new SortedList<List<string>, bool>()
            });
            caveRoomsList.Add(new CaveRoom // 2
            {
                Description = "You enter a smelly cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>(),
                PossiblePaths = new SortedList<List<string>, bool>()
            });

            // Building room #1
            // Generic keywords
            caveRoomsList[0].GenericKeywords.Add("feel", "You feel around, feeling relatively smooth walls");
            caveRoomsList[0].GenericKeywords.Add("look", "You can't see anything");
            caveRoomsList[0].GenericKeywords.Add("smell", "You smell the air, theres nothing escpecially of note");
            caveRoomsList[0].GenericKeywords.Add("walk", "You walk around, you can hear your step echo far indicating a large space");
            caveRoomsList[0].GenericKeywords.Add("listen", "You can hear running water somewhere, sounds like alot");

            // Unique keywords
            caveRoomsList[0].UniqueKeywords.Add("pickaxe", "You feel a wooden handle, it fits comfortable in your hands. You lift the weight and feel it to make sure, it's an old pickaxe. You could probably widen a tunnel with this");
            caveRoomsList[0].UniqueKeywords.Add("swim", "You consider jumping into the water for a while before carefully lowering yourself into the suprisingly deep cold stream. It's not as strong as you expected but you still have a hard time swimming");

            // Exploration unlocks
            caveRoomsList[0].ExplorationUnlocks.Add("pickaxe", false); 
            caveRoomsList[0].ExplorationUnlocks.Add("swim", false);

            // Possible paths
            caveRoomsList[0].PossiblePaths.Add(new List<string>() {"pickaxe", "swim"}, false);



            // Building room #2
            // Generic keywords

            // Unique keywords

            // Exploration unlocks

            // Possible paths



            // Gameplay loop necessities
            int currentRoom = 0;
            var currentRoomGenericSortedList = caveRoomsList[currentRoom].GenericKeywords;
            var currentRoomUniqueSortedList = caveRoomsList[currentRoom].UniqueKeywords;
            var currentRoomUnlocks = caveRoomsList[currentRoom].ExplorationUnlocks;
            var currentRoomPossiblePaths = caveRoomsList[currentRoom].PossiblePaths;

            // Describing and such
            Console.WriteLine(caveRoomsList[currentRoom].Description);

            //Looping systems
            while (true)
            {
                string playerInput = Console.ReadLine();
                string input = playerInput.ToLower();
                // Put player input into lowercase and handle possible word variations in method here
                keywordParser(input, currentRoomGenericSortedList, currentRoomUniqueSortedList, currentRoomUnlocks, currentRoomPossiblePaths);
            }
        }
    }
}
