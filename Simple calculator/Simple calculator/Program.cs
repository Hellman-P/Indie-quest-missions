using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Simple_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            while (true)
            {
                int randomItem = random.Next(5);

                var items = new List<string> { "Your own cleaning robot", "An entire shelf in the fridge", "Two posters of Matej", "Several empty coke cans", "A semi functional xbox controller" };

                Console.WriteLine($"Item: {items[randomItem]}");
                Console.Write("Set the price of this item: ");

                // Handling player input
                string input = Console.ReadLine();
                string[] splitInput = input.Split(' ');
                int y;
                int x;
                int price;
                int lastItem = splitInput.Length -1;

                y = Int16.Parse(splitInput[0]);

                if (splitInput.Length > 1)
                {
                    x = Int16.Parse(splitInput[lastItem]);

                    switch (splitInput[1])
                    {
                        case "+": case "plus": case "add": case "added":
                            price = y + x;
                            break;

                        case "-": case "minus": case "detract": case "detracted":
                            price = y - x;
                            break;

                        case "*": case "multiply": case "multiplied":
                            price = y * x;
                            break;

                        case "/": case "divide": case "divided":
                            price = y / x;
                            break;

                        default:
                            price = y;
                            break;
                    }

                }
                else
                {
                    price = y;
                }

                Console.WriteLine($"Price was set to: {price}$");
                Console.WriteLine("Price something else? (PRESS ENTER...)");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
