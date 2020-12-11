using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day10/input.txt";
            List<int> numbers = File.ReadAllLines(filePath).Select(int.Parse).ToList();
            numbers.Add(0);
            numbers.Sort();
            
            int numOneJ = 0;
            int numThreeJ = 1;

            for (var i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i+1] - numbers[i] == 1)
                {
                    numOneJ++;
                }

                if (numbers[i+1] - numbers[i] == 3)
                {
                    numThreeJ++;
                }
            }

            Console.WriteLine(numOneJ * numThreeJ);
            
            //Part two:
            long [] mem = new long[numbers.Count]; //Using array to store values otherwise solution is exponential
            FindPermutations(numbers, 0, mem);
            Console.WriteLine(mem.First());
        }

        public static long FindPermutations(List<int> numbers, int counter, long[] mem)
        {
            if (counter == numbers.Count - 1)
            {
                return 1;
            }

            long permutations = 0;

            if (mem[counter] != 0)
            {
                return mem[counter];
            }
            
            for (int i = counter + 1; i < numbers.Count; i++)
            {
                if (numbers[i] - numbers[counter] <= 3)
                {
                    permutations += FindPermutations(numbers, i, mem);
                }
            }

            mem[counter] = permutations;
            return permutations;
        }
    }
}
