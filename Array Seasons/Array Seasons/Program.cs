using System;

namespace Array_Seasons
{
    internal class Program
    {
        static void CreateDayDescription(int day, int season, int year)
        {
            string[] seasons = { "Spring", "Summer", "Autumn", "Winter" };

            Console.WriteLine($"{day}th day of {seasons[season]} in the year {year}");

        }
        static void Main(string[] args)
        {
            CreateDayDescription(5, 0 , 740);
            CreateDayDescription(7, 1, 740);
            CreateDayDescription(11, 2, 740);
            CreateDayDescription(14, 3, 740);
        }
    }
}
