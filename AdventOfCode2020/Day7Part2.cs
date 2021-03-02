using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{

    static class Day7Part2
    {
        static List<string> input = new List<string>(File.ReadAllLines("//inputfile"));
        static List<Bag> bagtypes = new List<Bag>();
        static int countbags = 0;
        public static void Execute()
        {
            //First make a list of the Bag class
            foreach (var rule in input)
            {
                bagtypes.Add(DefineColorsForBag(rule));
            }
            //Get the shinygoldbag
            var shinygoldbag = bagtypes.Where(x => x.OwnColor == "shinygold").FirstOrDefault();

            //And then count the bags
            CountBags(shinygoldbag, 1);
            Console.WriteLine($"Answer: {countbags}");
        }

        private static void CountBags(Bag bag, int times)
        {
            foreach (var rule in bag.ContainerRules)
            {
                //Count is used to add to the total and to set the times in the next recursion
                var count = rule.number * times;
                countbags += count;
                var getBagForRuleColor = bagtypes.Where(x => x.OwnColor == rule.color).ToList();
                if (getBagForRuleColor.Count() == 1)
                    CountBags(getBagForRuleColor[0], count);
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
                    if (string.Equals("no", stringToCompare) || string.Equals("0", stringToCompare))
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
