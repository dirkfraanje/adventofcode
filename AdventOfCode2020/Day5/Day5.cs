using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day5
{
    class Seat
    {
        public string Input { get; set; }

    }
    public static class Day5
    {
        static List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\DirkFraanje\\Documents\\adventofcodeday5.txt"));
        //static List<string> input = new List<string>() { "FFFBBBFRRR" };
        static List<int> seatnumbers = new List<int>();
        
        public static void Execute()
        {
            var timer = new Stopwatch();
            timer.Start();

            input.Sort();
            foreach (var seat in input)
            {
                seatnumbers.Add(GetSeatNumber(seat));
            }

            seatnumbers.Sort();
            int checkfor = 70;
            for (int i = 0; i < seatnumbers.Count-1; i++)
            {
                
                if (!(seatnumbers[i] == checkfor))
                    break;
                checkfor++;
            }
            timer.Stop();
            Console.WriteLine();
            Console.WriteLine($"Answer: {checkfor} ");
            Console.WriteLine($"Executed in: {timer.ElapsedMilliseconds} milliseconds ({timer.ElapsedTicks}  Ticks)");
        }
        public static int GetSeatNumber(string seatInput)
        {
            var row = seatInput.Substring(0, 7);
            var column = seatInput.Substring(7,3);

            int rowstart = 0;
            int rowend = 127;
            int difrow = 128;
            foreach (var direction in row)
            {
                if (direction == 'F')
                    rowend = rowend - (difrow / 2);
                else
                    rowstart = rowstart + (difrow / 2);
                difrow = difrow / 2;
            }
            int columnstart = 0;
            int columnend = 7;
            int difcolumn = 8;
            foreach (var direction in column)
            {
                if (direction == 'L')
                    columnend = columnend - (difcolumn / 2);
                else
                    columnstart = columnstart + (difcolumn / 2);
                difcolumn = difcolumn / 2;
            }


            return (rowend * 8) + columnend;
        }

    }

}