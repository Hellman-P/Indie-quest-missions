using System;

namespace Ordinal_Numbers
{
    internal class Program
    {
        static void OrdinalNumber(int number)
        {
            int lastDigit = (number % 10);
            int secondLastDigit = 0;

            if (number > 10)
            {
                secondLastDigit = (number / 10 % 10);
            }
            if (secondLastDigit == 1)
            {
                Console.WriteLine($"{number}th");
            }
            else if (lastDigit == 1)
            {
                Console.WriteLine($"{number}st");
            }
            else if (lastDigit == 2)
            {
                Console.WriteLine($"{number}nd");
            }
            else if (lastDigit == 3)
            {
                Console.WriteLine($"{number}rd");
            }
            else
            {
                Console.WriteLine($"{number}th");
            }
        }
        static void Main(string[] args)
        {
            OrdinalNumber(1);
            OrdinalNumber(5);
            OrdinalNumber(18);
            OrdinalNumber(22);
            OrdinalNumber(50);
            OrdinalNumber(66);
            OrdinalNumber(101);
            OrdinalNumber(253);
        }
    }
}
