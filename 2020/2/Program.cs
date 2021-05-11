using System;
using System.IO;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>();
            int answers = 0;

            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }

            foreach (string line in input)
            {
                int count = 0;
                int pos1;
                int pos2;
                string x;
                string target;

                pos1 = Convert.ToInt32(line.Split("-")[0]) - 1;
                pos2 = Convert.ToInt32(line.Split("-")[1].Split(" ")[0]) - 1;
                x = line.Split(" ")[1].Split(":")[0];
                target = line.Split(":")[1].Remove(0,1);

                if (target[pos1].Equals(x[0]))
                {
                    count++;
                }
                if(target[pos2].Equals(x[0]))
                {
                    count++;
                }
                if (count == 1)
                {
                    answers++;
                }
            }
            System.Console.WriteLine(answers);
        }
        /*PART 1 --> static void Main(string[] args)
        {
            List<string> input = new List<string>();
            int answers = 0;

            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }

            foreach (string line in input)
            {
                int count = 0;
                int min;
                int max;
                string x;
                string target;

                min = Convert.ToInt32(line.Split("-")[0]);
                max = Convert.ToInt32(line.Split("-")[1].Split(" ")[0]);
                x = line.Split(" ")[1].Split(":")[0];
                target = line.Split(":")[1].Remove(0,1);

                for (int i = 0; i < target.Length; i++)
                {
                    if (target[i].Equals(x[0]))
                    {
                        count++;
                    }
                }
                if (count >= min && count <= max)
                {
                    answers++;
                }
            }
            System.Console.WriteLine(answers);
        }*/
    }
}
