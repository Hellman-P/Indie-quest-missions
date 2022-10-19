using System;
using System.Collections.Generic;

namespace Travel_the_world_map
{
    internal class Program
    {
        static void ConnectLocations(Location a, Location b)
        {

        }
        class Location
        {
            public string Name;
            public string Description;
            public List<Location> Neighbors = new List<Location>();
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
                Description = "the capital of the Kingdom of the North"
            });
            locations.Add(new Location // 1
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands"
            });
            locations.Add(new Location // 2
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands"
            });
            locations.Add(new Location // 3
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros"
            });
            locations.Add(new Location // 4
            {
                Name = "King's Landing",
                Description = "the capital, and largest city, of the Seven Kingdoms"
            });
            locations.Add(new Location // 5
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and the regional capital of the Reach"
            });

            int randomStart = random.Next(0, locations.Count);
            currentLocation = locations[randomStart];
            Console.WriteLine($"You are currently in {currentLocation.Name}, {currentLocation.Description}\n");
            Console.WriteLine("if you wich to travel your possible destinations are:");
            Console.WriteLine();
        }
    }
}
