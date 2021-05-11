using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace _7
{
    class Program
    {
        List<string> input = new List<string>();
        static void Main(string[] args)
        {
            //System.Console.WriteLine(DateTime.Now.TimeOfDay);
            Program program = new Program();
            program.InitializeInput();
            program.RuleCheck("shiny gold");
            program.BagSizeCheck("shiny gold");
        }

        void InitializeInput()
        {
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }
        }

        void RuleCheck(string targetBag)
        {
            List<string> answerList = new List<string>();
            foreach (string line in input)
            {
                string[] a = line.Split(" contain ");
                string bag = a[0];
                bag = bag.Substring(0, bag.Length - 1);
                string rules = a[1];

                if (rules.Contains(targetBag) && !answerList.Contains(bag))
                {
                    answerList.Add(bag);
                    using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter("./output", true))
                            {
                                //file.WriteLine(bag);
                            }
                }
            }

            int prevAnswer = -1;
            do
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("./output", true))
                    {
                        //file.WriteLine("-------------------------------- NEW DO WHILE LOOP ----------------------------");
                    }
                prevAnswer = answerList.Count;
                foreach (string line in input)
                {
                    string[] a = line.Split(" contain ");
                    string bag = a[0];
                    bag = bag.Substring(0, bag.Length - 1);
                    string rules = a[1];

                    if (!answerList.Contains(bag))
                    {
                        if (answerList.Any(item => rules.Contains(item)))
                        {
                            answerList.Add(bag);
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter("./output", true))
                            {
                                //file.WriteLine(bag);
                            }
                        }
                    }
                }
            } while (answerList.Count != prevAnswer);
            System.Console.WriteLine(targetBag + " can be held by " + answerList.Count + " bag colors");
        }

        void BagSizeCheck(string targetBag)
        {
            List<string> answerList = new List<string>();
            int prevAnswer = -1;
            do
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("./output", true))
                    {
                        file.WriteLine("-------------------------------- NEW DO WHILE LOOP ----------------------------");
                    }
                prevAnswer = answerList.Count;
                foreach (string line in input)
                {
                    string[] a = line.Split(" contain ");
                    string bag = a[0];
                    bag = bag.Substring(0, bag.Length - 1);
                    string rules = a[1];

                    if (!answerList.Contains(bag))
                    {
                        if (answerList.Any(item => rules.Contains(item)))
                        {
                            //System.Console.WriteLine(bag);
                            answerList.Add(bag);
                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter("./output", true))
                            {
                                file.WriteLine(bag);
                            }
                        }
                    }
                }
                //System.Console.WriteLine("Done");
            } while (answerList.Count != prevAnswer);
            System.Console.WriteLine(targetBag + " is required to contain " + answerList.Count + " bags");
        }
    }
}
