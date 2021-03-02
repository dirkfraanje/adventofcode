using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    static class Day10
    {

        static int counterDif1 = 0;
        static int counterDif3 = 0;
        static List<int> input;

        public static void Execute()
        {
            input = File.ReadAllLines("c:\\users\\DirkFraanje\\Documents\\adventofcodeday10.txt").Select(r=> int.Parse(r)).ToList();

            //Added a imer just for fun
            var timer = new Stopwatch();
            timer.Start();

            input.Insert(0, 0);
            input.Sort();
            for (int i = input.Count-1; i >= 1; i--)
            {
                var dif = input[i] - input[i-1];
                if (dif == 1)
                    counterDif1++;
                else if (dif == 3)
                    counterDif3++;
                else
                    throw new Exception($"{dif}");
            }
            //Finally add the last adapter to your device
            counterDif3++;
            
            timer.Stop();
            Console.WriteLine($"1 jolts difference: {counterDif1} ");
            Console.WriteLine($"3 jolts difference: {counterDif3} ");
            Console.WriteLine($"1-jolts multiplied by 3-jolts: {counterDif1 * counterDif3}");
            Console.WriteLine($"Executed in: {timer.ElapsedMilliseconds} milliseconds, {timer.ElapsedTicks} ticks");
        }

       
    }
}
