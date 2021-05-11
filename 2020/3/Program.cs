using System;
using System.IO;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        List<string> input = new List<string>();
        int position = 0;
        int mapWidth;

        int GetIndex(int pos)
        {
            return (pos%mapWidth);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializeInput();

            System.Console.WriteLine("With 3, 1: " + program.TreeCount(3, 1));
            System.Console.WriteLine((program.TreeCount(1, 1)*program.TreeCount(3, 1)*program.TreeCount(5, 1)*program.TreeCount(7, 1)*program.TreeCount(1, 2)));
        }

        void InitializeInput()
        {
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }
            mapWidth = input[0].Length;
        }

        long TreeCount(int x, int y)
        {
            position = 0;
            long answer = 0;
            for (int i = y; i < input.Count; i = (i+y))
            {
                position = position + x;
                if (input[i][GetIndex(position)].Equals("#"[0]))
                {
                    answer++;
                }
                //System.Console.WriteLine("{0} {1} {2}", input[i][GetIndex(position)], GetIndex(position), i + 1);
            }
            //System.Console.WriteLine(answer);
            return answer;
        }
    }
}
