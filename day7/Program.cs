using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day7
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day7/input.txt";
            string[] rules = File.ReadAllLines(filePath);

            List<string> startingPoints = new List<string>();
            Dictionary<string, string> ruleDictionary = new Dictionary<string, string>();
            HashSet<string> bags = new HashSet<string>();

            foreach (string rule in rules)
            {
                var split = rule.Split(new string[] {" bags"}, 2, StringSplitOptions.RemoveEmptyEntries);
                
                ruleDictionary.Add(split[0], split[1]);

                if (split[1].Contains("shiny gold"))
                {
                    startingPoints.Add(split[0]);
                    bags.Add(split[0]);
                }
            }

            foreach (string key in startingPoints)
            {
                FindAllBags(key, ruleDictionary, bags);
            }

            Console.WriteLine("PART 1:");
            Console.WriteLine(bags.Count);

            Console.WriteLine("PART 2");
            
            // -1 as we aren't including the first "shiny gold" bag
            int individualBags = CountIndividualBags(ruleDictionary, "shiny gold", 1) - 1;
            Console.WriteLine(individualBags);
        }

        public static void FindAllBags(string key, Dictionary<string, string> ruleDictionary, HashSet<string> bags)
        {
            var findKeys = ruleDictionary.Where(x => x.Value.Contains(key))
                .Select(x => x.Key).ToList();

            foreach (string findKey in findKeys)
            {
                if (!bags.Contains(findKey))
                {
                    bags.Add(findKey);
                    FindAllBags(findKey, ruleDictionary, bags);
                }
            }
        }

        public static int CountIndividualBags(Dictionary<string, string> ruleDictionary, string key, int numInBag)
        {
            Regex rx = new Regex("[0-9]+ [a-zA-Z]+ [a-zA-Z]+");

            string[] bags = rx.Matches(ruleDictionary[key]).Select(s => s.Value).ToArray();
            
            int newCount = 0;
            
            foreach (string bag in bags)
            {
                key = Regex.Match(bag, "[a-zA-Z]+ [a-zA-Z]+").ToString();

                int count = int.Parse(Regex.Match(bag, "[0-9]+").Value);
                
                newCount += CountIndividualBags(ruleDictionary, key, count);
            }
            
            return numInBag * newCount + numInBag;;
        }
    }
}
