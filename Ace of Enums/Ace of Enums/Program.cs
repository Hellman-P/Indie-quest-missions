using System;

namespace Ace_of_Enums
{
    internal class Program
    {
        enum Suits
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs,
        }
        static void DrawAce(Suits suit)
        {
            string icon = "Placeholder";

            if (suit == Suits.Hearts)
            {
                icon = "♥";
            }
            else if (suit == Suits.Spades)
            {
                icon = "♠";
            }
            else if (suit == Suits.Diamonds)
            {
                icon = "♦";
            }
            if (suit == Suits.Clubs)
            {
                icon = "♣";
            }

            Console.WriteLine("╭───────╮");
            Console.WriteLine("│A      │");
            Console.WriteLine($"│{icon}      │");
            Console.WriteLine($"│   {icon}   │");
            Console.WriteLine($"│      {icon}│");
            Console.WriteLine("│      A│");
            Console.WriteLine("╰───────╯");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DrawAce(Suits.Hearts);
            DrawAce(Suits.Spades);
            DrawAce(Suits.Diamonds);
            DrawAce(Suits.Clubs);
        }
    }
}
