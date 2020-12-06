using System;
using System.Collections.Generic;
using System.IO;

namespace day5
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day5/input.txt";
            string[] boardingPasses = File.ReadAllLines(filePath);

            int highestSeatId = 0;

            List<int> seatIds = new List<int>();
            
            foreach (var boardingPass in boardingPasses)
            {
                int max = 127;
                int min = 0;
                int maxColumn = 7;
                int minColumn = 0;
                foreach (char c in boardingPass)
                {
                    if (c == 'F')
                    {
                        max -= (max - min) / 2 + 1;
                    }

                    if (c == 'B')
                    {
                        min += (max - min) / 2 + 1;
                    }

                    if (c == 'L')
                    {
                        maxColumn -= (maxColumn - minColumn) / 2 + 1;
                    }
                    
                    if (c == 'R')
                    {
                        minColumn += (maxColumn - minColumn) / 2 + 1;
                    }
                }

                int row = max;
                int column = maxColumn;

                int seatId = (row * 8) + column;
                seatIds.Add(seatId);

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }

            Console.WriteLine("PART 1:");
            Console.WriteLine(highestSeatId);

            //Part 2:
            Console.WriteLine("PART 2:");
            seatIds.Sort();
            for (int i = 0; i < seatIds.Count; i++)
            {
                if (seatIds[i+1] - seatIds[i] == 2)
                {
                    Console.WriteLine(seatIds[i] + 1);
                    break;
                }
            }
        }
    }
}
