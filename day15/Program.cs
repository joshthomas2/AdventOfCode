using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day15
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day15/input.txt";
            int[] numbers = Array.ConvertAll(File.ReadAllText(filePath).Split(','), int.Parse);
            
            int[] limits = {2020, 30000000};
            foreach (int limit in limits)
            {
                int lastNumberSpoken = numbers.Last();
                int answer = RunGame(lastNumberSpoken, numbers, limit);
                Console.WriteLine("Limit: " + limit);
                Console.WriteLine("Last number spoken: " + answer + "\n");
            }
        }

        public static int RunGame(int lastNumberSpoken, int[] numbers, int limit)
        {
            int startingTurns = 1;
            List<int>[] numbersSpoken = new List<int>[limit + 1];

            //starting turns
            foreach (int number in numbers)
            {
                numbersSpoken[number] = new List<int>{startingTurns};
                startingTurns++;
            }
            
            for (int turn = startingTurns; turn <= limit; turn++)
            {
                if (numbersSpoken[lastNumberSpoken] == null)
                {
                    lastNumberSpoken = 0;
                    numbersSpoken[lastNumberSpoken] = new List<int>{turn};
                    continue;
                }
                if (numbersSpoken[lastNumberSpoken].Count == 1)
                {
                    lastNumberSpoken = 0;
                    numbersSpoken[lastNumberSpoken].Add(turn);
                    continue;
                }

                int lastIndex = numbersSpoken[lastNumberSpoken].Count - 1;
                lastNumberSpoken = numbersSpoken[lastNumberSpoken][lastIndex] - numbersSpoken[lastNumberSpoken][lastIndex - 1];

                if (numbersSpoken[lastNumberSpoken] == null)
                {
                    numbersSpoken[lastNumberSpoken] = new List<int>{turn};
                    continue;
                }

                numbersSpoken[lastNumberSpoken].Add(turn);
            }

            return lastNumberSpoken;
        }
    }
}
