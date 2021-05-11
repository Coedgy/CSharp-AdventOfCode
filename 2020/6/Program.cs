using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    class Program
    {
        List<string> input = new List<string>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializeInput();
            program.CountAnswers();
        }

        void InitializeInput()
        {
            System.Console.WriteLine("Reading input file...");
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }
        }

        void CountAnswers()
        {
            System.Console.WriteLine("Counting answers...");
            List<Char> answerListP1 = new List<Char>();
            List<Char> answerListP2 = new List<Char>();
            List<Char> alreadyAnswered = new List<Char>();
            int totalAnswersP1 = 0;
            int totalAnswersP2 = 0;
            int lineCount = 0;
            foreach (string line in input)
            {
                if (line.Length == 0)
                {
                    string a = string.Join(' ',answerListP2);
                    //System.Console.WriteLine(a);
                    //System.Console.WriteLine(lineCount);
                    foreach (Char entry in answerListP2)
                    {
                        if (entry != ' ')
                        {
                            if (a.Count(f => (f == entry)) == lineCount && !alreadyAnswered.Contains(entry))
                            {
                                //System.Console.WriteLine("P2 true");
                                totalAnswersP2++;
                                alreadyAnswered.Add(entry);
                            }
                        }
                    }
                    alreadyAnswered.Clear();
                    //System.Console.WriteLine(answerList.ToArray());
                    totalAnswersP1 = totalAnswersP1 + answerListP1.Count;
                    lineCount = 0;
                    answerListP1.Clear();
                    answerListP2.Clear();
                }
                else
                {
                    lineCount++;
                }

                foreach (Char letter in line)
                {
                    if (!answerListP1.Contains(letter))
                    {
                        answerListP1.Add(letter);
                    }
                    answerListP2.Add(letter);
                }
            }
            string b = string.Join(' ',answerListP2);
            foreach (Char entry in answerListP2)
            {
                if (entry != ' ')
                {
                    if (b.Count(f => (f == entry)) == lineCount && !alreadyAnswered.Contains(entry))
                    {
                        //System.Console.WriteLine("P2 true");
                        totalAnswersP2++;
                        alreadyAnswered.Add(entry);
                    }
                }
            }
            alreadyAnswered.Clear();
            //System.Console.WriteLine(answerList.ToArray());
            totalAnswersP1 = totalAnswersP1 + answerListP1.Count;
            answerListP1.Clear();
            answerListP2.Clear();
            System.Console.WriteLine("Part 1: " + totalAnswersP1);
            System.Console.WriteLine("Part 2: " + totalAnswersP2);
        }
    }
}
