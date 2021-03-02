using AdventOfCode2020.Day1;
using AdventOfCode2020.Day2;
using AdventOfCode2020.Day3;
using AdventOfCode2020.Day4;
using AdventOfCode2020.Day5;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class Days
    {
        int _day;
        public int Part;

        public Days(int day)
        {
            _day = day;
        }

        public void Execute()
        {
            if (_day == 1 && Part == 1)
            {
                Day1Part1.Execute();
            }
            else if (_day == 1 && Part == 2)
            {
                Day1Part2.Execute();
            }
            else if (_day == 2 && Part == 1)
            {
                Day2Part1.Execute();
            }
            else if (_day == 2 && Part == 2)
            {
                Day2Part2.Execute();
            }
            else if (_day == 3)
            {
                Day3.Day3.Execute();
            }
            else if (_day == 4 && Part == 1)
            {
                Day4.Day4.Execute();
            }
            else if (_day == 5 && Part == 1)
            {
                Day5.Day5.Execute();
            }
            else if (_day == 6)
            {
                Day6.Day6.Execute();
            }
            else if (_day == 7 && Part == 1)
            {
                Day7Part1.Execute();
            }
            else if (_day == 7 && Part == 2)
            {
                Day7Part2.Execute();
            }
            else if (_day == 8)
            {
                Day8.Execute();
            }
            else if (_day == 9)
            {
                Day9.Execute();
            }
            else if (_day == 10 && Part ==1)
            {
                Day10.Execute();
            }
            else if (_day == 10 && Part ==2)
            {
                Day10Part2.Execute();
            }
            else
                Console.WriteLine("Day / part not found");
            
        }
    }
}
