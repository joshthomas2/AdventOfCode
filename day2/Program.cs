using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day2/input.txt";
            string[] passwords = File.ReadAllLines(filePath);
            
            Regex rx = new Regex(@"(\d+)-(\d+) ([a-zA-Z])");
            // SolutionOne(rx, passwords);
            //
            // string Text = "11-17 z: hwzdfvbpbxzfpjwmzq";
            // string[] splitString = Text.Split(":");
            // char letterToCount = splitString[0].Last();
            // string[] digits = Regex.Split(Text, @"\d+");
            // Array.ConvertAll(digits, int.Parse);
            //
            // int count = 0;
            // foreach (Char c in splitString[1])
            // {
            //     if (c == letterToCount)
            //     {
            //         count++;
            //     }
            // }
            
            
            // foreach (string value in digits)  
            // {  
            //     int number;  
            //     if (int.TryParse(value, out number))  
            //     {  
            //         Console.WriteLine(value);  
            //     }  
            // }

   
            SolutionOne(rx, passwords);
            SolutionTwo(rx, passwords);
        }

        public static void SolutionOne(Regex rx, string[] passwords)
        {
            int masterCount = 0;
            foreach (string password in passwords)
            {
                int count = 0;
                MatchCollection matches = rx.Matches(password);

                int lowestN = int.Parse(matches.First().Groups[1].Value);
                    int highestN = int.Parse(matches.First().Groups[2].Value);
                    Char letterToCount = char.Parse(matches.First().Groups[3].Value);
                
                
                string[] splitString = password.Split(":");

                foreach (char c in splitString.Last())
                {
                    if (c == letterToCount)
                    {
                        count++;
                    }
                }

                if (count >= lowestN && count <= highestN)
                {
                    masterCount++;
                }
            }

            Console.WriteLine(masterCount);
        }
        
        public static void SolutionTwo(Regex rx, string[] passwords)
        {
            int masterCount = 0;
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
                    masterCount++;
                }
            }

            Console.WriteLine(masterCount);
        }
    }
}
