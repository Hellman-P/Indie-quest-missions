using System;

namespace Party_Dilemma
{
    internal class Program
    {
        static int Factorial(int n)
        {
            if(n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int result = Factorial(10);

            Console.WriteLine(result);
        }
    }
}
