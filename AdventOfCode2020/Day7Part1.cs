using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    class Rule
    {
        public int number { get; set; }
        public string color { get; set; }
        public Rule(int num, string col)
        {
            number = num;
            color = col;
        }
    }
    class Bag
    {
        public string OwnColor { get; set; }
        public List<Rule> ContainerRules { get; set; }
        public bool isCounted { get; set; }
        public Bag(string owncolor)
        {
            OwnColor = owncolor;
            ContainerRules = new List<Rule>();
        }
    }
    static class Day7Part1
    {
        static List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\DirkFraanje\\Documents\\adventofcodeday7.txt"));
        static List<Bag> bagtypes = new List<Bag>();
        static int countShinyGolds = 0;
        public static void Execute()
        {
            foreach (var rule in input)
            {
                bagtypes.Add(DefineColorsForBag(rule));
            }
            var directshinygoldbaglist = bagtypes.Where(x => x.ContainerRules.Any(r => r.color == "shinygold"));

            numberOfShinyGold(directshinygoldbaglist);
            Console.WriteLine($"Answer: {countShinyGolds}");
        }

        private static void numberOfShinyGold(IEnumerable<Bag> bags)
        {
            foreach (var item in bags)
            {
                if (!item.isCounted)
                {
                    countShinyGolds++;
                    item.isCounted = true;
                }
                var bagsWhereRulesContainItemColor = bagtypes.Where(x => x.ContainerRules.Any(c => c.color == item.OwnColor));
                numberOfShinyGold(bagsWhereRulesContainItemColor);
            }
        }
        private static Bag DefineColorsForBag(string rule)
        {
            var splitrule1 = rule.Split(' ');
            var bag = new Bag(splitrule1[0] + splitrule1[1]);

            var splitrule2 = rule.Split(' ').Skip(3).ToArray();
            int i = 0;
            while (true)
            {
                var stringToCompare = splitrule2[i];
                if (stringToCompare.Contains(".") || string.Equals("no", stringToCompare))
                    return bag;
                if (stringToCompare.Contains(',') || stringToCompare.Contains("bag") || string.Equals("contain", stringToCompare))
                {
                    i++;
                    stringToCompare = splitrule2[i];
                    if (string.Equals("no", stringToCompare))
                        return bag;
                    int.TryParse(stringToCompare, out int t);
                    bag.ContainerRules.Add(new Rule(t, splitrule2[i + 1] + splitrule2[i + 2]));
                    i += 3;
                }

            }




            return bag;
        }


    }
}
