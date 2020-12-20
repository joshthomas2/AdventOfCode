using System;
using System.IO;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "/Users/joshthomas/Documents/AdventOfCode/day13/input.txt";
            string[] lines = File.ReadAllLines(filePath);

            int partOneTimeStamp = int.Parse(lines[0]);
            string[] buses = lines[1].Split(',');
            int[] onlyBusNumbers = Array.ConvertAll(lines[1].Split(new Char [] {',', 'x'}, StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int shortestWait = onlyBusNumbers[0] - (partOneTimeStamp % onlyBusNumbers[0]);
            int busNumber = onlyBusNumbers[0];
            
            foreach (var bus in onlyBusNumbers)
            {

                int wait = bus - (partOneTimeStamp % bus);

                if (wait < shortestWait)
                {
                    shortestWait = wait;
                    busNumber = bus;
                }
            }

            Console.WriteLine(busNumber * shortestWait);
            
            //part 2:
            //Timestamp must be divisible by the first bus.
            //Need to keep x's in
            //startTimestamp = bus[0]
            //foreach i = 1 : bus.length
            //    timestamp = bus[i]
            //    if(timestamp % bus[i] != 0): 

            //USE CHINESE REMAINDER THEOREM
            long partTwoTimeStamp = 0;
            long earliestTimeStamp = partTwoTimeStamp;
            bool foundTimeStamp = false;
            do
            {
                partTwoTimeStamp += onlyBusNumbers[0];
                earliestTimeStamp = partTwoTimeStamp;

                for (int i = 1; i < buses.Length; i++)
                {
                    partTwoTimeStamp++;
                    if (buses[i] == "x")
                    {
                        continue;
                    }

                    if (partTwoTimeStamp % int.Parse(buses[i]) != 0)
                    {
                        foundTimeStamp = false;
                        break;
                    }

                    foundTimeStamp = true;
                }
            } while (foundTimeStamp == false);

            Console.WriteLine("part2: " + earliestTimeStamp);
        }
    }
}
