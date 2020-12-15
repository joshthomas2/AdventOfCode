using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day02/input.txt";
            string[] passwords = File.ReadAllLines(filePath);
            
            Regex rx = new Regex(@"(\d+)-(\d+) ([a-zA-Z])");

            SolutionOne(rx, passwords);
            SolutionTwo(rx, passwords);
        }

        public static void SolutionOne(Regex rx, string[] passwords)
        {
            int validPasswords = 0;
            foreach (string password in passwords)
            {
                int count = 0;
                
                MatchCollection matches = rx.Matches(password);

                int lowLimit = int.Parse(matches.First().Groups[1].Value);
                int highLimit = int.Parse(matches.First().Groups[2].Value);
                
                Char letterToCount = char.Parse(matches.First().Groups[3].Value);
                    
                string[] splitString = password.Split(":");

                foreach (char c in splitString.Last())
                {
                    if (c == letterToCount)
                    {
                        count++;
                    }
                }

                if (count >= lowLimit && count <= highLimit)
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
        }
        
        public static void SolutionTwo(Regex rx, string[] passwords)
        {
            int validPasswords = 0;
            
            foreach (string password in passwords)
            {
                int count = 0;
                MatchCollection matches = rx.Matches(password);

                int indexOne = int.Parse(matches.First().Groups[1].Value);
                int indexTwo = int.Parse(matches.First().Groups[2].Value);
                
                Char letterToFind = char.Parse(matches.First().Groups[3].Value);

                string[] splitString = password.Split(":");

                if (splitString.Last()[indexOne] == letterToFind ^ splitString.Last()[indexTwo] == letterToFind)
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
        }
    }
}
