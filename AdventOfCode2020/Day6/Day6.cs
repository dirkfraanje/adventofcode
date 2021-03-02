using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day6
{
    class Day6
    {
        static List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\DirkFraanje\\Documents\\adventofcodeday6.txt"));
        static int count = 0;
        static int skipcounter = 0;
        static int linecounter = 0;
        public static void Execute()
        {
            foreach (var line in input)
            {
                if (!string.IsNullOrEmpty(line))
                    linecounter++;
                else
                {
                    Calculate();
                    linecounter++;
                    skipcounter += linecounter;
                    linecounter = 0;
                }
            }
            Calculate();
            Console.WriteLine();
            Console.WriteLine($"Answer: {count} ");
        }

        private static void Calculate()
        {
            var lines = input.Skip(skipcounter).Take(linecounter).ToList();

            if (lines.Count == 1)
            {
                HashSet<char> set = new HashSet<char>(lines[0].ToCharArray());
                count += set.Count;
                return;
            }
            List<char> q = new List<char>();
            for (int i2 = 0; i2 < lines.Count - 1; i2++)
            {
                if (i2 == 0)
                    q = lines[i2].Intersect(lines[i2 + 1]).ToList();
                else
                    q = q.Intersect(lines[i2 + 1]).ToList();
            }
            HashSet<char> set2 = new HashSet<char>(q);
            count += set2.Count;
        }
    }
}
