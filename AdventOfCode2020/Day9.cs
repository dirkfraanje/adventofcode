using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    static class Day9
    {
        //Declaring numberToConsider so it can easily be changed when testing
        static int numberToConsider = 25;
        static List<long> input;
        static int firstposition = numberToConsider;
        static long faultingNumber;
        public static void Execute()
        {
            input = File.ReadAllLines("c:\\users\\DirkFraanje\\Documents\\adventofcodeday9.txt").Select(r=> long.Parse(r)).ToList();

            //Added a imer just for fun
            var timer = new Stopwatch();
            timer.Start();

            while (true)
            {
                faultingNumber = input[firstposition];
                if (!SumFound(faultingNumber, firstposition))
                    break;
                firstposition++;
            }
            //Part 2:
            var answerPart2 = FindSumUpToAnswer();
            
            timer.Stop();
            Console.WriteLine($"Part1 answer:  {faultingNumber}");
            Console.WriteLine($"Part2 answer:  {answerPart2}");
            Console.WriteLine($"Executed in: {timer.ElapsedMilliseconds} milliseconds");
        }

        private static long FindSumUpToAnswer()
        {
            firstposition = 0;
            var secondPosition = 1;
            

            while (true)
            {
                var listToCheck = input.GetRange(firstposition, secondPosition-firstposition);
                var rangeResult = listToCheck.Sum();
                if (rangeResult == faultingNumber)
                {
                    return listToCheck.Min() + listToCheck.Max();
                }
                //By adding to either the first or second position a window is created and results are re-used instead of creating a new list every time
                if (rangeResult < faultingNumber)
                    secondPosition++;
                else
                    firstposition++;
            }
        }

        private static bool SumFound(long nextNumberToCheck, int position)
        {
            var workingList = input.Skip(position - numberToConsider).Take(numberToConsider).ToList();
            workingList.Sort();
            for (int i = 0; i < numberToConsider-1; i++)
            {
                var valueNeeded = nextNumberToCheck - workingList[i];
                var result = workingList.BinarySearch(valueNeeded);
                if (result >= 0)
                    return true;
            }
            return false;
        }
    }
}
