using System;
using System.Collections.Generic;

int Factorial(int n)
{
    // Figuring out how many rounds are needed to be fair
    if (n == 0)
    {
        return 1;
    }
    else
    {
        return n * Factorial(n - 1);
    }
}
List<string> ShuffleList(List<string> gamers, List<string> shuffled)
{
    // Generating random orders
    Random random = new Random();

    var gamersCopy = new List<string>(gamers);
    shuffled.Clear();

    for (int i = 0; i < gamers.Count; i++)
    {
        int randomIndex = random.Next(gamersCopy.Count);
        shuffled.Add(gamersCopy[randomIndex]);
        gamersCopy.Remove(gamersCopy[randomIndex]);
    }

    return shuffled;
}
//Variabels
var gamers = new List<string> { "Allie", "Ben", "Claire"};
var shuffled = new List<string> { };
int numberOfPlayers = gamers.Count;
int result = Factorial(numberOfPlayers);

//Displating Result
Console.WriteLine($"The players who will participate in game are: {string.Join(", ", gamers)} \n");
Console.WriteLine($"Generating all possible starting positions for {numberOfPlayers} players...\n");
for (int i = 0; i < result; i++)
{
    ShuffleList(gamers, shuffled);
    Console.WriteLine($"Order of scrubs in session {i+1} are: {string.Join(", ", shuffled)} ");
}
