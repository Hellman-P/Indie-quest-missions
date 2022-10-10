using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace A_better_join
{
    internal class Program
    {
        static void JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            var itemsCopy = new List<string>(items);

            // OG list
            // No items
            if (items.Count == 0)
            {
                Console.WriteLine();
            }

            // Only one item
            else if (items.Count == 1)
            {
                Console.WriteLine(items[0]);
            }
            // More than 1 items
            else if (items.Count == 2) //I made this to work with more than 2 also because I can't read
            {
                for (int i = 0; i < items.Count - 1; i++)
                {
                    Console.Write(items[i]);
                    if (i < items.Count - 2)
                    {
                        Console.Write(" ,");
                    }
                }
                Console.WriteLine($" and {items[items.Count - 1]}");
                Console.WriteLine();
            }

            // Copied List
            else if (useSerialComma)
            {
                string lastItem = itemsCopy[itemsCopy.Count - 1];

                string serialComma = "and " + lastItem;
                itemsCopy.Add(serialComma);
                itemsCopy.Remove(lastItem);

                Console.WriteLine(string.Join(", ", itemsCopy));
            }
            else
            {
                string lastItem = itemsCopy[itemsCopy.Count - 1];
                string secondLastItem = itemsCopy[itemsCopy.Count - 2];

                string andCombo = secondLastItem + " and " + lastItem;

                itemsCopy.Remove(lastItem);
                itemsCopy[itemsCopy.Count - 1] = andCombo;

                Console.WriteLine(string.Join(", ", itemsCopy));
            }

        }
        static void Main(string[] args)
        {
            var items = new List<string> { "Alucard" };

            JoinWithAnd(items, true);
            Console.WriteLine();
            JoinWithAnd(items, false);

            // "Alucard", "Rudeus", "Canti", "Hoosuki"
        }
    }
}
