using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day4
{
    public static class Day4
    {
        static List<string> passwords = new List<string>() { };
        static int validpassports = 0;
        static string workingOnPassport = "";
        public static void Execute()
        {
            var timer = new Stopwatch();
            timer.Start();


            var passports = new List<string>(File.ReadAllLines("C:\\Users\\DirkFraanje\\Documents\\advofcodeday4.txt"));
            foreach (var passportline in passports.ToArray())
            {
                if (string.IsNullOrEmpty(passportline))
                {
                    ValidatePassport();
                    continue;
                }
                workingOnPassport += workingOnPassport == "" ? passportline : " " + passportline;
            }
            if (!string.IsNullOrEmpty(workingOnPassport))
                ValidatePassport();
            timer.Stop();
            Console.WriteLine();
            Console.WriteLine($"Answer: {validpassports} valid passports");
            Console.WriteLine($"Executed in: {timer.ElapsedMilliseconds} milliseconds ({timer.ElapsedTicks}  Ticks)");
        }

        private static void ValidatePassport()
        {
            var items = workingOnPassport.Split(' ');
            if (!(items.Length >= 8 || (items.Length == 7 && !workingOnPassport.Contains("cid"))))
            {
                workingOnPassport = "";
                return;
            }

            bool valid = true;
            foreach (var item in items)
            {
                if (!valid)
                {
                    workingOnPassport = "";
                    return;
                }

                var keyvaluepair = item.Split(':');
                switch (keyvaluepair[0])
                {
                    case "byr":
                        var byr = Convert.ToInt32(keyvaluepair[1]);
                        valid = byr >= 1920 && byr <= 2002;
                        break;
                    case "iyr":
                        var iyr = Convert.ToInt32(keyvaluepair[1]);
                        valid = iyr >= 2010 && iyr <= 2020;
                        break;
                    case "eyr":
                        var eyr = Convert.ToInt32(keyvaluepair[1]);
                        valid = eyr >= 2020 && eyr <= 2030;
                        break;
                    case "hgt":
                        var keyvalue = keyvaluepair[1];
                        var measureType = keyvalue.Substring(keyvalue.Length - 2, 2);
                        if (measureType != "cm" && measureType != "in")
                        {
                            valid = false;
                            break;
                        }
                        var heightvalue = Convert.ToInt32(keyvalue.Substring(0, keyvalue.Length - 2));
                        if (measureType == "cm" && heightvalue >= 150 && heightvalue <= 193)
                            break;
                        if (measureType == "in" && heightvalue >= 59 && heightvalue <= 76)
                            break;
                        valid = false;
                        break;
                    case "hcl":
                        if (!Regex.Match(keyvaluepair[1], "^#[0-9a-f]{6}$").Success)
                        {
                            valid = false;
                            break;
                        }
                        break;
                    case "ecl":
                        var eyecolor = keyvaluepair[1];
                        if (!string.Equals("amb", eyecolor) && !string.Equals("blu", eyecolor) && !string.Equals("brn", eyecolor) && !string.Equals("gry", eyecolor) && !string.Equals("grn", eyecolor) && !string.Equals("hzl", eyecolor) && !string.Equals("oth", eyecolor))
                        {
                            valid = false;
                            break;
                        }
                        break;
                    case "pid":
                        if (!Regex.Match(keyvaluepair[1], "^[0-9]{9}$").Success)
                        {
                            valid = false;
                            break;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (valid)
            {
                validpassports++;
            }
            workingOnPassport = "";
        }
    }
}