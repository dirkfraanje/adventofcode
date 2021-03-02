using AdventOfCode2015.Day1;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2015
{
    public class Days
    {
        int _day;
        int _part;

        public Days(int day, int part)
        {
            _day = day;
            _part = part;
        }

        public void Execute()
        {
            if (_day == 1 && _part == 1)
            {
                Day1Part1.Execute();
            }
            else if (_day == 2 && _part == 1)
            {
                Day2Part1.Execute();
            }
            else if (_day == 2 && _part == 2)
            {
                Day2Part2.Execute();
            }
            else if (_day == 3 && _part == 1)
            {
                Day3Part1.Execute();
            }
            else
                Console.WriteLine("Day / part not found");

        }
    }

}
