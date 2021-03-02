using System;

namespace AdventOfCode2015
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteDay();
        }
        private static void ExecuteDay()
        {
            Console.WriteLine("Choose a day:");
            var day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose a daypart:");
            var daypart = Convert.ToInt32(Console.ReadLine());
            var days = new Days(day, daypart);
            days.Execute();
            Console.WriteLine();
            ExecuteDay();
        }
    }
}
