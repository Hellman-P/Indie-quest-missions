using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Net.WebSockets;

namespace Road_Generator
{
    internal class Program
    {
        static Random random = new Random();
        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {
            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            if (direction == 3) // up
            {
                for (int y = startY; y <= height-1; y++)
                {
                    roads[startX, y] = true;
                }
            }
            else if (direction == 0) // right
            {
                for (int x = startX; x <= width-1; x++)
                {
                    roads[x, startY] = true;
                }
            }
            else if (direction == 1) // down
            {
                    for (int y = startY; y >= 0; y--) 
                    {
                        roads[startX, y] = true;
                    }
            }
            else if (direction == 2) // left
            {
                for (int x = startX; x >= 0; x--)
                {
                    roads[x, startY] = true;
                }
            }
        }
        static void Main(string[] args)
        {
            // Generate Map
            bool[,] map = new bool[50, 20];
            int width = map.GetLength(0);
            int height = map.GetLength(1);

            for (int i = 0; i < 5; i++)
            {
                GenerateRoad(roads: map, startX: random.Next(width), startY: random.Next(height), direction: random.Next(4));
            }
            
            // Draw Map
            for (int y = height-1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(map[x, y] ? "#" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
