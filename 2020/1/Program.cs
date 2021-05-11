using System;
using System.IO;
using System.Collections.Generic;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = new List<int>();
            List<int> threeNumbers = new List<int>();

            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                int value = Convert.ToInt32(line);
                numbersList.Add(value);
            }

            for (int i = 0; i < numbersList.Count; i++)
            {
                for (int x = 0; x < numbersList.Count; x++)
                {
                    for (int o = 0; o < numbersList.Count; o++)
                    {
                        if (o != x && o != i && x != o && numbersList[i] + numbersList[o] + numbersList[x] == 2020)
                        {
                            threeNumbers.Add(numbersList[o]);
                        }
                    }
                }
            }
            foreach (int i in threeNumbers)
            {
                System.Console.WriteLine(i);
            }
            System.Console.WriteLine("Answer: " + threeNumbers[0]*threeNumbers[1]*threeNumbers[2]);
        }
    }
}
