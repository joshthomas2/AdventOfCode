using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day4
{
    class Program
    {
        static void Main()
        {
            var file = File.ReadAllText("/Users/joshthomas/Documents/AdventOfCode/day04/input.txt");

            string[] passports = file.Split(new string[] { "\n\n" },
                StringSplitOptions.RemoveEmptyEntries);
            
            string[] requiredFields = {"byr", "ecl", "eyr", "hcl", "hgt", "pid", "iyr"};
            
            var sortedPassports = SortPassports(passports);

            //Set this to true for part2
            bool validateData = true;

            PrintValidCount(requiredFields, sortedPassports, validateData);
        }

        public static void PrintValidCount(string[] requiredFields, List<Dictionary<string, string>> sortedPassports, bool validateData)
        {
            int validCount = 0;

            foreach (var passport in sortedPassports)
            {
                bool isValid = ValidateAllFields(requiredFields, passport, validateData);

                if (isValid)
                {
                    validCount++;
                }
            }
            
            Console.WriteLine(validCount);
        }

        public static List<Dictionary<string, string>> SortPassports(string[] passports)
        {
            List<Dictionary<string, string>> sortedPassports = new List<Dictionary<string, string>>();
            
            foreach (var passport in passports)
            {
                var fields = passport.Split(new char[] {' ', '\n'}).Select(s => s.Split(":"));
                var dict = fields.ToDictionary(s => s[0], s => s[1]);
                sortedPassports.Add(dict);
            }

            return sortedPassports;
        }

        public static bool ValidateAllFields(string[] requiredFields, Dictionary<string, string> sortedPassport, bool validateData)
        {
            foreach (string field in requiredFields)
            {
                if (!sortedPassport.Keys.Any(s => s.Contains(field)))
                {
                    return false;
                }
                
                if(validateData)
                {
                    switch (field)
                    {
                        case "byr":
                            int byrData = int.Parse(sortedPassport[field]);
                            if (byrData < 1920 || byrData > 2002)
                            {
                                return false;
                            }
                            break;
                        
                        case "iyr":
                            int iyrData = int.Parse(sortedPassport[field]);
                            if (iyrData < 2010 || iyrData > 2020)
                            {
                                return false;
                            }
                            break;
                        
                        case "eyr":
                            int eyrData = int.Parse(sortedPassport[field]);
                            if (eyrData < 2020 || eyrData > 2030)
                            {
                                return false;
                            }
                            break;
                        
                        case "hgt":
                            var hgtData = int.Parse(Regex.Match(sortedPassport[field],"\\d+").Groups[0].Value);

                            if (sortedPassport[field].Contains("cm") && hgtData < 150
                                || sortedPassport[field].Contains("cm") && hgtData > 193)
                            {
                                return false;
                            }
                            
                            if (sortedPassport[field].Contains("in") && hgtData < 59
                                || sortedPassport[field].Contains("in") && hgtData > 76)
                            {
                                return false;
                            }

                            if (!sortedPassport[field].Contains("in") && !sortedPassport[field].Contains("cm"))
                            {
                                return false;
                            }
                            break;
                        
                        case "hcl":
                            var hclData = sortedPassport[field];
                            
                            if (hclData[0] != '#' || hclData.Length != 7 || Regex.IsMatch(hclData, "[g-zG-Z]+"))
                            {
                                return false;
                            }
                            break;
                        
                        case "ecl":
                            var eclData = sortedPassport[field];
                            
                            if (eclData != "amb" 
                             && eclData != "blu"
                             && eclData != "brn"
                             && eclData != "gry"
                             && eclData != "grn"
                             && eclData != "hzl"
                             && eclData != "oth")
                            {
                                return false;
                            }
                            break;
                        
                        case "pid":
                            var pidData = sortedPassport[field];

                            if (pidData.Length != 9)
                            {
                                return false;
                            }
                            break;
                        //Ignoring cid as not needed.
                    }
                }
            }
            return true;
        }
    }
}
