using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace day9
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day09/input.txt";
            long[] numbers = Array.ConvertAll(File.ReadAllLines(filePath), long.Parse);

            var sw = new Stopwatch();
            sw.Start();
            int i = 25; //start on 26th number.
            
            while (IsValid(numbers, numbers[i], i - 25, i))
            {
                i++;
            }
            
            var invalidNumber = numbers[i];
            Console.WriteLine("First number to not follow rule:" + invalidNumber);

            var encryptionWeakness = FindEncryptionWeakness(numbers, invalidNumber);
            Console.WriteLine("Encryption weakness:" + encryptionWeakness);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        
        public static bool IsValid(long[] numbers, long number, int start, int end)
        {
            HashSet<long> numbersToFind = new HashSet<long>();

            for (var i = start; i < end; i++)
            {
                long numberToFind = number - numbers[i];

                if (numbersToFind.Contains(numberToFind))
                {
                    return true;
                }

                numbersToFind.Add(numbers[i]);
            }

            return false;
        }

        public static long FindEncryptionWeakness(long[] numbers, long invalidNumber)
        {
            int firstNumIndex = 0;

            List<long> contiguousList = new List<long>();
            
            long sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                contiguousList.Add(numbers[i]);

                sum += numbers[i];

                while (sum > invalidNumber)
                {
                    sum -= numbers[firstNumIndex];
                    firstNumIndex++;
                    
                    contiguousList.RemoveAt(0);
                }

                if (sum == invalidNumber)
                {
                    break;
                }
            }

            return contiguousList.Min() + contiguousList.Max();
        }
    }
}
