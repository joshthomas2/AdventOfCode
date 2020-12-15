using System;
using System.Collections.Generic;
using System.IO;

namespace day8
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day08/input.txt";
            string[] instructions = File.ReadAllLines(filePath);

            Console.WriteLine("PART 1:");
            int accumulator = 0;
            FindAccumulatorValue(instructions, ref accumulator);
            Console.WriteLine(accumulator);

            Console.WriteLine("PART 2:");
            Console.WriteLine(FindCorruptInstruction(instructions));
        }

        public static int FindAccumulatorValue(string[] instructions, ref int accumulator)
        {
            bool exit = false;
            int counter = 0;
            
            HashSet<int> index = new HashSet<int>();
            
            while (exit == false)
            {
                if (index.Contains(counter))
                {
                    break;
                }

                if (counter >= instructions.Length)
                {
                    break;
                }

                index.Add(counter);
                
                var instruction = instructions[counter].Split(new string[] {" ", "+", "-"}, StringSplitOptions.RemoveEmptyEntries);
                
                if (instruction[0] == "nop")
                {
                    counter++;
                    continue;
                }

                bool positive = instructions[counter].Contains("+");

                if (instruction[0] == "acc")
                {
                    accumulator = positive ? accumulator + int.Parse(instruction[1]) : accumulator - int.Parse(instruction[1]);
                    counter++;
                    continue;
                }
                
                if (instruction[0] == "jmp")
                {
                    counter = positive ? counter + int.Parse(instruction[1]) : counter - int.Parse(instruction[1]);
                }
            }

            return counter;
        }

        public static int FindCorruptInstruction(string[] instructions)
        {
            int accumulator = 0;

            for (var i = 0; i < instructions.Length; i++)
            {
                var instruction = instructions[i];
                accumulator = 0;

                if (instruction[0] == 'a')
                {
                    continue;
                }

                if (instruction[0] == 'n')
                {
                    instructions[i] = instructions[i].Replace("nop", "jmp");
                    int counter = FindAccumulatorValue(instructions, ref accumulator);

                    if (counter >= instructions.Length)
                    {
                        break;
                    }

                    instructions[i] = instruction.Replace("jmp", "nop");
                }

                if (instruction[0] == 'j')
                {
                    instructions[i] = instruction.Replace("jmp", "nop");
                    int counter = FindAccumulatorValue(instructions, ref accumulator);

                    if (counter >= instructions.Length)
                    {
                        break;
                    }

                    instructions[i] = instruction.Replace("nop", "jmp");
                }
            }

            return accumulator;
        }
    }
}
