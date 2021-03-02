using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    static class Day10Part2
    {

        static int counterDif1 = 0;
        static int counterDif3 = 0;
        static List<string> input;
        static List<string> newlist;
        static int options = 1;
        public static void Execute()
        {
            newlist = new List<string>();
            input = File.ReadAllLines("c:\\users\\DirkFraanje\\Documents\\assocationcheck.txt").ToList();
            int i = 1;
            foreach (var item in input)
            {
                if (i >= input.Count - 1)
                    break;
                if (item.StartsWith('L') && input[i + 1].StartsWith('P'))
                    newlist.Add(input[i + 1]);
                i++;
            }

            foreach (var item in newlist)
            {
                Console.WriteLine($"{item}");
            }
            
        }


    }
}
