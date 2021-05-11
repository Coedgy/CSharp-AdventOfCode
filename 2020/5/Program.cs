using System;
using System.IO;
using System.Collections.Generic;

namespace _5
{
    class Program
    {
        List<string> input = new List<string>();

        List<int> rowList = new List<int>();
        List<int> columnList = new List<int>();
        List<int> idList = new List<int>();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializeInput();
            program.RegisterPassports();

            int topID = 0;
            program.idList.Sort();
            int prevID = program.idList[0]-1;
            foreach (int id in program.idList)
            {
                if (id > topID)
                {
                    topID = id;
                }
                //System.Console.WriteLine(id);
                if (id-1 != prevID)
                {
                    System.Console.WriteLine("Your ID: " + (id-1));
                }
                prevID = id;
            }
            System.Console.WriteLine("Biggest ID on the list: " + topID);

            program.rowList.Sort();

            foreach (int row in program.rowList)
            {
                //System.Console.WriteLine(row);
            }
        }

        void InitializeInput()
        {
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }
        }

        void RegisterPassports()
        {
            for (int i = 0; i < input.Count; i++)
            {
                int rMin = 1;
                int rMax = 128;
                int cMin = 1;
                int cMax = 8;

                string rString = input[i].Substring(0,7);
                string cString = input[i].Substring(7,3);
                
                foreach (char letter in rString)
                {
                    if (letter.Equals('F')) //bottom half
                    {
                        rMax = rMax-((rMax-rMin)/2)-1;
                    }
                    else if (letter.Equals('B')) //top half
                    {
                        rMin = rMin+((rMax-rMin)/2)+1;
                    }
                }
                foreach (char letter in cString)
                {
                    if (letter.Equals('L')) //bottom half
                    {
                        cMax = cMax-((cMax-cMin)/2)-1;
                    }
                    else if (letter.Equals('R')) //top half
                    {
                        cMin = cMin+((cMax-cMin)/2)+1;
                    }
                }
                rowList.Add(rMax-1);
                columnList.Add(cMax-1);
                idList.Add(rowList[i]*8+columnList[i]);
                
                //System.Console.WriteLine(idList[i] + " - " +rowList[i] + "-" + columnList[i]);
            }
        }
    }
}
