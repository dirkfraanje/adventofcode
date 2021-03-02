using AdventOfCode2020.Day1;
using System;
using System.Linq;

namespace AdventOfCode2020
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
            int.TryParse(Console.ReadLine(), out int daypart);
            var days = new Days(day) { Part = daypart};
            days.Execute();
            Console.WriteLine();
            ExecuteDay();
        }
    }
}
