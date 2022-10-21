using System;
using System.Collections.Generic;

namespace Travel_the_world_map
{
    internal class Program
    {
        class Location
        {
            public string Name;
            public string Description;
            public List<Location> Neighbors = new List<Location>();
        }
        static void ConnectLocations(Location a, Location b)
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }
        static void Main(string[] args)
        {
            Random random = new Random();

            var locations = new List<Location>();
            Location currentLocation = new Location();

            // Destinations
            locations.Add(new Location // 0
            {
                Name = "Winterfell",
                Description = "the capital of the Kingdom of the North",
                Neighbors = new List<Location>()
            });
            locations.Add(new Location // 1
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy",
                Neighbors = new List<Location>()
            });
            locations.Add(new Location // 2
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands",
                Neighbors = new List<Location>()
            });
            locations.Add(new Location // 3
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros",
                Neighbors = new List<Location>()
            });
            locations.Add(new Location // 4
            {
                Name = "King's Landing",
                Description = "the capital, and largest city, of the Seven Kingdoms",
                Neighbors = new List<Location>()
            });
            locations.Add(new Location // 5
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and the regional capital of the Reach",
                Neighbors = new List<Location>()
            });

            // Adding Neighbors
            ConnectLocations(locations[0], locations[1]);
            ConnectLocations(locations[0], locations[3]);
            ConnectLocations(locations[1], locations[2]);
            ConnectLocations(locations[1], locations[5]);
            ConnectLocations(locations[2], locations[3]);
            ConnectLocations(locations[2], locations[4]);
            ConnectLocations(locations[2], locations[5]);
            ConnectLocations(locations[4], locations[3]);
            ConnectLocations(locations[4], locations[5]);

            int randomStart = random.Next(0, locations.Count);
            currentLocation = locations[randomStart];

            // Interface
            interfaceLoop:
            Console.WriteLine($"You are currently in {currentLocation.Name}, {currentLocation.Description}\n");
            Console.WriteLine("if you wish to travel your possible destinations are:\n");

            for (int i = 0; i < currentLocation.Neighbors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentLocation.Neighbors[i].Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Where do you wish to travel? (Type number and press ENTER...)");
            int choosenDestination = Convert.ToInt32(Console.ReadLine())-1;
            currentLocation = locations[choosenDestination]; //moving between destinations instead of neighbors
            Console.Clear();
            goto interfaceLoop;
        }
    }
}
