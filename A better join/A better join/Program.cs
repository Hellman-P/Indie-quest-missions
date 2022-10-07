using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace A_better_join
{
    internal class Program
    {
        static void JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
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
            else if (items.Count > 1)
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



            var itemsCopy = new List<string>(items);

            if (useSerialComma == true)
            {

            }
            else
            {
                string lastItem = itemsCopy[itemsCopy.Count - 1];
                string secondLastItem = itemsCopy[itemsCopy.Count - 2];
                string andCombo = secondLastItem + " and " + lastItem;

                itemsCopy.Insert(itemsCopy.Count - 2, andCombo);

                itemsCopy.Remove(secondLastItem);
                itemsCopy.Remove(lastItem);

                Console.WriteLine(string.Join(", ", itemsCopy));
            }

        }
        static void Main(string[] args)
        {
            var items = new List<string> { "Alucard", "Rudeus", "Canti", "Hoosuki" };

            JoinWithAnd(items, false);

            // "Alucard", "Rudeus", "Canti", "Hoosuki"
        }
    }
}
