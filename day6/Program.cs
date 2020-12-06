using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main()
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day6/input.txt";
            string file = File.ReadAllText(filePath);
            string[] groupForms = file.Split(new string[] {"\n\n"}, StringSplitOptions.RemoveEmptyEntries);

            int numberOfYeses = 0;
            int commonYeses = 0;

            foreach (var groupForm in groupForms)
            {
                List<char> questions = new List<char>();
                
                foreach (char c in groupForm)
                {
                    if (!questions.Contains(c) && c != '\n')
                    {
                        questions.Add(c);
                        
                        int qCount = groupForm.Count(x => x == c);

                        if (qCount == groupForm.Split("\n").Length)
                        {
                            commonYeses++;
                        }
                    }
                }

                numberOfYeses += questions.Count;
            }

            Console.WriteLine("PART 1:");
            Console.WriteLine(numberOfYeses);

            Console.WriteLine("PART 2:");
            Console.WriteLine(commonYeses);
        }
    }
}
