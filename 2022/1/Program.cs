using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("./input");

            List<int> allEntries = new List<int>();

            int maxTotalCalories = 0;
            int currentIteration = 0;

            foreach (string line in lines)
            {
                if (line == string.Empty)
                {
                    if (currentIteration > maxTotalCalories)
                    {
                        maxTotalCalories = currentIteration;
                    }

                    allEntries.Add(currentIteration);
                    currentIteration = 0;
                    continue;
                }

                int value = Convert.ToInt32(line);

                currentIteration += value;
            }

            allEntries = allEntries.OrderByDescending(x => x).ToList();

            System.Console.WriteLine("Top 1 elf: " + maxTotalCalories + " calories.");
            System.Console.WriteLine("Top 3 elfs combined: " + (allEntries[0] + allEntries[1] + allEntries[2]) + " calories.");
        }
    }
}
