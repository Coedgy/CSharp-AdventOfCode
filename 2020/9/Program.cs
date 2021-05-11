using System;
using System.IO;
using System.Collections.Generic;

namespace _9
{
    class Program
    {
        List<string> input = new List<string>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializeInput();
            program.Code();
        }

        void InitializeInput()
        {
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }
        }

        void Code()
        {
            
        }
    }
}