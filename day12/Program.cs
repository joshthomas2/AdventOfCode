using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day12
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day12/input.txt";
            string[] actions = File.ReadAllLines(filePath);
            
            Dictionary<char, int> partOnePosition = new Dictionary<char, int>
            {
                {'N', 0},
                {'E', 0},
                {'S', 0},
                {'W', 0}
            };

            Dictionary<char, int> partTwoPosition = new Dictionary<char, int>
            {
                {'x', 0},
                {'y', 0},
            };
            
            //weypoints for part2
            int x = 10;
            int y = 1;

            EvadeTheStorm(actions, partOnePosition, partTwoPosition, x, y);
            
            int partOneDistance = Math.Abs(partOnePosition['E'] - partOnePosition['W']) + Math.Abs(partOnePosition['S'] - partOnePosition['N']);

            int partTwoDistance = Math.Abs(partTwoPosition['x']) + Math.Abs(partTwoPosition['y']);

            Console.WriteLine("Part1: " + partOneDistance);
            Console.WriteLine("Part2: " + partTwoDistance);
        }

        public static void EvadeTheStorm(string[] actions, Dictionary<char, int> partOnePosition, Dictionary<char, int> partTwoPosition, int x, int y)
        {
            int index = 1; //For a starting direction of East in part 1

            foreach (var action in actions)
            {
                int value = int.Parse(action.Substring(1));
                
                if (action[0] == 'L')
                {
                    index -= value / 90;
                    
                    int partTwoClicks = value / 90;
                    for (int i = 0; i < partTwoClicks; i++)
                    {
                        int newX = -y;
                        int newY = x;

                        x = newX;
                        y = newY;
                    }
                }

                if (action[0] == 'R')
                {
                    index += value / 90;
                    
                    int partTwoClicks = value / 90;
                    for (int i = 0; i < partTwoClicks; i++)
                    {
                        int newX = y;
                        int newY = -x;

                        x = newX;
                        y = newY;
                    }
                }

                if (action[0] == 'F')
                {
                    index %= 4;
                    char key = index >= 0 ? partOnePosition.ElementAt(index).Key : partOnePosition.ElementAt(index + 4).Key;
                    partOnePosition[key] += value;

                    partTwoPosition['y'] += value * y;
                    partTwoPosition['x'] += value * x;
                }

                switch (action[0])
                {
                    case 'W':
                        x -= value;
                        break;
                    case 'E':
                        x += value;
                        break;
                    case 'N':
                        y += value;
                        break;
                    case 'S':
                        y -= value;
                        break;
                }
            }
        }
    }
}
