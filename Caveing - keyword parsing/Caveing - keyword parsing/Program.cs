using Microsoft.VisualBasic;
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
            public SortedList<int, List<string>> PossiblePathsTriggers = new SortedList<int, List<string>>(); 
            public SortedList<int, bool> PossiblePathsBooleans = new SortedList<int, bool>();
            public SortedList<int, string> PathExitText = new SortedList<int, string>();
            public SortedList<int, int> PathLeadsToRoom = new SortedList<int, int>();
        }


        static void uniqueKeywordUnlocks(string input, SortedList<string, string> uniqueKeywords, SortedList<string, bool> unlocks)
        {
            // Writing unique keyword text and also unlocking exploration keys
            Console.WriteLine(uniqueKeywords[input]);
            unlocks[input] = true;
        }


        static void roomExitManager(SortedList<int, List<string>> pathTriggers, SortedList<int, bool> pathBooleans,SortedList<string, bool> unlocks, SortedList<int, string> exitPathText)
        {
            Console.WriteLine("I could consider moving forwards, maybe I should?");

            // Separating player input into list of strings
            string playerInput = Console.ReadLine();
            string playerInputLower = playerInput.ToLower();
            string[] separatedPlayerInput = playerInputLower.Split(' ', ',', '.');

            // Checking of the player wants to move to another room
            foreach (string input in separatedPlayerInput)
            {
                switch (input)
                {
                    case "yes":
                    case "y":
                        // Checking what options the player has unlocked and showing what they can do

                        // Putting true keywords in list
                        var foundKeywords = new List<string>();
                        foreach (KeyValuePair<string, bool> keyValue in unlocks)
                        {
                            if (keyValue.Value == true)
                                foundKeywords.Add(keyValue.Key);
                        }

                        // Comparing each possible paths keywords with found keywords
                        foreach (KeyValuePair<int, List<string>> listOfTriggers in pathTriggers)
                        {
                            bool b = true;
                            foreach (string pathTrígger in listOfTriggers.Value)
                            {
                                if (!foundKeywords.Contains(pathTrígger))
                                {
                                    b = false;
                                    break;
                                }
                            }
                            if (b == true)
                            {
                                pathBooleans[listOfTriggers.Key] = true;
                            }
                        }

                        break;

                    case "no":
                    case "n":
                        Console.WriteLine("Not now, I need to explore more");
                        break;

                    default:
                        Console.WriteLine("I'll consider it later...");
                        break;
                }

                Console.WriteLine("The plausible options are probably..."); // make this only trigger if player answered POSITIVE
                int listingOtions = 1;
                foreach (KeyValuePair<int, bool> keyValue in pathBooleans)
                {
                    if (keyValue.Value == true)
                    {
                        Console.Write($"{listingOtions}. ");
                        Console.WriteLine(exitPathText[keyValue.Key]);
                        Console.WriteLine();
                        listingOtions++;
                    }
                }
                // READLINE player input and somehow change room number based on what option they choose
            }

        }


        static void keywordParser(string playerInput, SortedList<string, string> genericKeywords, SortedList<string, string> uniqueKeywords, SortedList<string, bool> unlocks, SortedList<int, List<string>> pathTriggers, SortedList<int, bool> pathBooleans, SortedList<int, string> exitPathText)
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
                        roomExitManager(pathTriggers, pathBooleans, unlocks, exitPathText);
                        break;

                    default:
                        break;
                }
            }
        }

        static void AlternativeWords(string playerInput)
        {
            // Separating player input into list of strings
            string[] separatedPlayerInput = playerInput.Split(' ', ',', '.');
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
                PossiblePathsTriggers = new SortedList<int, List<string>>(),
                PossiblePathsBooleans = new SortedList<int, bool>(),
                PathExitText = new SortedList<int, string>(),
                PathLeadsToRoom = new SortedList<int, int>()
            });
            caveRoomsList.Add(new CaveRoom // 1
            {
                Description = "You enter a wet cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>(),
                PossiblePathsTriggers = new SortedList<int, List<string>>(),
                PossiblePathsBooleans = new SortedList<int, bool>(),
                PathExitText = new SortedList<int, string>(),
                PathLeadsToRoom = new SortedList<int, int>()
            });
            caveRoomsList.Add(new CaveRoom // 2
            {
                Description = "You enter a smelly cave...",
                GenericKeywords = new SortedList<string, string>(),
                UniqueKeywords = new SortedList<string, string>(),
                ExplorationUnlocks = new SortedList<string, bool>(),
                PossiblePathsTriggers = new SortedList<int, List<string>>(),
                PossiblePathsBooleans = new SortedList<int, bool>(),
                PathExitText = new SortedList<int, string>(),
                PathLeadsToRoom = new SortedList<int, int>()
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
            caveRoomsList[0].UniqueKeywords.Add("fish", "wow! a fish in a cave");
            caveRoomsList[0].UniqueKeywords.Add("dog", "wow! a dog in a cave");

            // Exploration unlocks
            caveRoomsList[0].ExplorationUnlocks.Add("pickaxe", false); 
            caveRoomsList[0].ExplorationUnlocks.Add("swim", false);
            caveRoomsList[0].ExplorationUnlocks.Add("fish", false);
            caveRoomsList[0].ExplorationUnlocks.Add("dog", false);

            // Possible path triggers
            caveRoomsList[0].PossiblePathsTriggers.Add(0, new List<string>() { "pickaxe", "swim" });
            caveRoomsList[0].PossiblePathsTriggers.Add(1, new List<string>() { "fish", "dog" });

            // Possible path triggers
            caveRoomsList[0].PossiblePathsBooleans.Add(0, false);
            caveRoomsList[0].PossiblePathsBooleans.Add(1, false);

            // Exit Path texts
            caveRoomsList[0].PathExitText.Add(0, "Should I use this pickaxe as an oar and try to paddle my way out?");
            caveRoomsList[0].PathExitText.Add(1, "There is a chance the fish and dog could combine their power to let me move further");

            // What room different exits lead too
            caveRoomsList[0].PathLeadsToRoom.Add(0,1);
            caveRoomsList[0].PathLeadsToRoom.Add(1, 2);


            // Gameplay loop necessities
            int currentRoom = 0;
            var currentRoomGenericSortedList = caveRoomsList[currentRoom].GenericKeywords;
            var currentRoomUniqueSortedList = caveRoomsList[currentRoom].UniqueKeywords;
            var currentRoomUnlocks = caveRoomsList[currentRoom].ExplorationUnlocks;
            var currentRoomPathTriggers = caveRoomsList[currentRoom].PossiblePathsTriggers;
            var currentRoomPathBooleans = caveRoomsList[currentRoom].PossiblePathsBooleans;
            var currentRoomPathExitTexts = caveRoomsList[currentRoom].PathExitText;
            var currentRoomPathLeadsTo = caveRoomsList[currentRoom].PathLeadsToRoom;


            // Describing and such
            while (true)
            {
                Console.WriteLine(caveRoomsList[currentRoom].Description);

                //Looping systems
                while (true)
                {
                    // Take player input, put it into lowercase and pass it to the AlternativeWords
                    string playerInput = Console.ReadLine();
                    string input = playerInput.ToLower();
                    AlternativeWords(input); // Make this do something and use it before keywordParser
                    keywordParser(input, currentRoomGenericSortedList, currentRoomUniqueSortedList, currentRoomUnlocks, currentRoomPathTriggers, currentRoomPathBooleans, currentRoomPathExitTexts);

                }
            }




            // Move this into exit room manager or a method called in that
            // use current path leads too
            int listingOtions = 1;
            foreach (KeyValuePair<int, bool> keyValue in currentRoomPathBooleans)
            {
                if (keyValue.Value == true)
                {
                    Console.Write($"{listingOtions}. ");
                    Console.WriteLine(currentRoomPathExitTexts[keyValue.Key]);
                    Console.WriteLine();
                    listingOtions++;
                }
            }
        }
    }
}
