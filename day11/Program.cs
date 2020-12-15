using System;
using System.Collections.Generic;
using System.IO;

namespace day11
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day11/input.txt";
            string[] file = File.ReadAllLines(filePath);
            int width = file[0].Length;
            int height = file.Length;
            char[,] seatPlan = new Char[height, width];
            int occupiedSeats = 0;

            for (var row = 0; row < height; row++)
            {
                file[row].Split("\n");
                for (int col = 0; col < width; col++)
                {
                    seatPlan[row, col] = file[row][col];

                    if (seatPlan[row, col] == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }
            
            //Part 1:
            Console.WriteLine("Part 1 occupied seats:");
            Console.WriteLine(CountOccupiedSeats(seatPlan, height, width, false, 4, occupiedSeats));
            
            //Part 2:
            Console.WriteLine("Part 2 occupied seats:");
            Console.WriteLine(CountOccupiedSeats(seatPlan, height, width, true, 5, occupiedSeats));
        }

        public static int CountOccupiedSeats(char[,] seatPlan, int height, int width, bool part2, int tolerance, int occupiedSeats)
        {
            bool notEqual;
            do
            {
                char[,] newSeatPlan = (char[,]) seatPlan.Clone();
                
                notEqual = false;
                
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        switch (seatPlan[row, col])
                        {
                            case 'L':
                                if (OccupiedSeatChecker(row, col, seatPlan, part2) == 0)
                                {
                                    newSeatPlan[row, col] = '#';
                                    occupiedSeats++;
                                    notEqual = true;
                                }
                                break;
                            
                            case '#':
                                if (OccupiedSeatChecker(row, col, seatPlan, part2) >= tolerance)
                                {
                                    newSeatPlan[row, col] = 'L';
                                    occupiedSeats--;
                                    notEqual = true;
                                }
                                break;
                        }
                    }
                }

                seatPlan = (char[,]) newSeatPlan.Clone();
            } while (notEqual);
            
            return occupiedSeats;
        }

        public static int OccupiedSeatChecker(int row, int col, char[,] seatPlan, bool part2)
        {
            int occupiedSeats = 0;

            var adjacentSeats = new List<int[]>();
            adjacentSeats.Add(new[] {-1, -1});
            adjacentSeats.Add(new[] {-1, 0});
            adjacentSeats.Add(new[] {-1, 1});
            adjacentSeats.Add(new[] {0, -1});
            adjacentSeats.Add(new[] {0, 1});
            adjacentSeats.Add(new[] {1, -1});
            adjacentSeats.Add(new[] {1, 0});
            adjacentSeats.Add(new[] {1, 1});
            
            foreach (int[] seat in adjacentSeats)
            {
                try
                {
                    int y = row + seat[0];
                    int x = col + seat[1];
                    
                    if (part2)
                    {
                        while (seatPlan[y,x] == '.')
                        {
                            y += seat[0];
                            x += seat[1];
                        }
                    }
                    
                    if (seatPlan[y,x] == '#')
                    {
                        occupiedSeats++;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }
            }
            
            return occupiedSeats;
        }
    }
}
