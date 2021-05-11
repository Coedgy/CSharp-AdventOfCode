using System;
using System.IO;
using System.Collections.Generic;

namespace _8
{
    class Program
    {
        List<string> inputF = new List<string>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializeInput();
            //program.Part1();
            program.Part2();
            program.Part1();
        }

        void InitializeInput()
        {
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                inputF.Add(line);
            }
        }

        void Part1()
        {
            List<string> input = new List<string>(inputF);
            int acc = 0;
            List<int> history = new List<int>();

            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("./output", true))
                    {
                        file.WriteLine("1");
                    }

            for (int i = 0; i < input.Count;)
            {
                System.Console.WriteLine(i);

                if (history.Contains(i))
                {
                    //System.Console.WriteLine(i + 1 + " is running for the second time. Value in acc: " + acc);
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("./output", true))
                    {
                        file.WriteLine(i + 1 + " is running for the second time. Value in acc: " + acc);
                    }
                    break;
                }

                history.Add(i);

                string command = input[i].Substring(0, 3);
                string valueS = input[i].Split(" ")[1];

                if (valueS.Contains('+'))
                {
                    valueS = valueS.Split("+")[1];
                }
                int value = Convert.ToInt32(valueS);

                if (command.Equals("acc"))
                {
                    acc = acc + value;
                    i++;
                }
                else if (command.Equals("jmp"))
                {
                    i = i + value;
                }
                else if (command.Equals("nop"))
                {
                    i++;
                }
                else
                {
                    System.Console.WriteLine("NO COMMAND FOUND!");
                }
                //System.Console.WriteLine(i + 1);
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter("./output", true))
                    {
                        file.WriteLine(i + 1);
                    }
            }
        }
    
        void Part2()
        {
            int limit = 10000;
            int line = 0;

            for (int x = 0; x < inputF.Count; x++)
            {
                List<string> input = new List<string>(inputF);
                string commandM = input[x].Substring(0, 3);

                if (!commandM.Equals("acc"))
                {
                    if (commandM.Equals("jmp"))
                    {
                        input[x] = input[x].Replace("jmp", "nop");
                    }else if (commandM.Equals("nop"))
                    {
                        input[x] = input[x].Replace("nop", "jmp");
                    }else
                    {
                        System.Console.WriteLine("NO COMMAND FOUND!");
                        break;
                    }
                    //System.Console.WriteLine(input[x]);
                    int acc = 0;
                    int count = 0;

                    for (int i = 0; i < input.Count - 1;)
                    {
                        count++;
                        string command = input[i].Substring(0, 3);
                        string valueS = input[i].Split(" ")[1];

                        if (valueS.Contains('+'))
                        {
                            valueS = valueS.Split("+")[1];
                        }
                        int value = Convert.ToInt32(valueS);

                        if (command.Equals("acc"))
                        {
                            acc = acc + value;
                            i++;
                        }
                        else if (command.Equals("jmp"))
                        {
                            i = i + value;
                        }
                        else if (command.Equals("nop"))
                        {
                            i++;
                        }
                        else
                        {
                            System.Console.WriteLine("NO COMMAND FOUND!");
                            break;
                        }
                        if (count > limit)
                        {
                            break;
                        }
                    }
                    if (count >= limit)
                    {
                        //System.Console.WriteLine(x + 1 + " was not the line");
                    } else
                    {
                        System.Console.WriteLine(x + 1 + " was the line! Value in acc: " + acc);
                        line = x + 1;
                    }
                }
                if (x == 10)
                {
                    foreach (var item in inputF)
                    {
                        System.Console.WriteLine(item);
                    }
                }
            }
            System.Console.WriteLine(line);
        }    
    }
}