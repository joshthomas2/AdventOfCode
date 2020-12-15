using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(SolutionOne(3, 1));
            
            SolutionTwo();
        }

        static int SolutionOne(int moveRight, int moveDown)
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day03/input.txt";
            string[] lines = File.ReadAllLines(filePath);
            
            int lineWidth = lines[0].Length;

            int counter = 0;
            int treesEncountered = 0;

            for (int i = 0; i < lines.Length; i += moveDown)
            {
                if (lines[i][counter] == '#')
                {
                    treesEncountered++;
                }

                counter = counter + moveRight;

                if (counter >= lineWidth)
                {
                    counter -= lineWidth;
                }
            }

            return treesEncountered;
        }
        
        static void SolutionTwo()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day3/part2.txt";
            string[] slopes = File.ReadAllLines(filePath);

            long totalTrees = 1;
            
            foreach (var slope in slopes)
            {
                string[] numbers = Regex.Split(slope, @"\D+");
                int moveRight = int.Parse(numbers[1]);
                int moveDown = int.Parse(numbers[2]);
                
                int treesEncountered = SolutionOne(moveRight, moveDown);
                totalTrees *= treesEncountered;
            }

            Console.WriteLine(totalTrees);
        }
    }
}
