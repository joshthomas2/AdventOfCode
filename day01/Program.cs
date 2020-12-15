using System;
using System.Collections.Generic;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day01/input.txt";
            int[] numbers = Array.ConvertAll(File.ReadAllLines(filePath), int.Parse);

            SolutionOne(numbers);
            SolutionTwo(numbers);
        }

        public static void SolutionOne(int[] numbers)
        {
            HashSet<int> numbersToFind = new HashSet<int>();

            foreach (int num in numbers)
            {
                int numberToFind = 2020 - num;

                if (numbersToFind.Contains(numberToFind))
                {
                    Console.WriteLine(num * numberToFind);
                }

                numbersToFind.Add(num);
            }
        }
        
        public static void SolutionTwo(int[] numbers)
        {
            HashSet<int> numbersToFind = new HashSet<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int numberToFind = 2020 - numbers[i];

                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbersToFind.Contains(numberToFind - numbers[j]))
                    {
                        Console.WriteLine(numbers[i] * numbers[j] * (numberToFind - numbers[j]));
                        return;
                    }
                }
                numbersToFind.Add(numbers[i]);
            }
        }
    }
}
