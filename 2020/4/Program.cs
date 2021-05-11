using System;
using System.IO;
using System.Collections.Generic;

namespace _4
{
    static public class Extensions
    {
        public static bool ContainsAny(this string haystack, params string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }

            return false;
        }
    }

    class Program
    {
        List<string> input = new List<string>();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializeInput();
            program.CheckPassports();
        }

        void CheckPassports()
        {
            bool byr, iyr, eyr, hgt, hcl, ecl, pid;
            byr = false; iyr = false; eyr = false; hgt = false; hcl = false; ecl = false; pid = false;
            int validCount = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Length == 0)
                {
                    if (byr == true && iyr == true && eyr == true && hgt == true && hcl == true && ecl == true && pid == true)
                    {
                        //System.Console.WriteLine(i);
                        validCount++;
                    }
                    byr = false; iyr = false; eyr = false; hgt = false; hcl = false; ecl = false; pid = false;
                }
                if (input[i].Contains("byr"))
                {
                    string a = input[i].Split("byr:")[1];
                    if (a.Length > 4)
                    {
                        a = a.Substring(0,4);
                    }
                    if (a.Length == 4 && Convert.ToInt32(a) >= 1920 && Convert.ToInt32(a) <= 2002)
                    {
                        byr = true;
                    }
                }
                if (input[i].Contains("iyr"))
                {
                    string a = input[i].Split("iyr:")[1].Substring(0,4);
                    if (a.Length == 4 && Convert.ToInt32(a) >= 2010 && Convert.ToInt32(a) <= 2020)
                    {
                        iyr = true;
                    }
                }
                if (input[i].Contains("eyr"))
                {
                    string a = input[i].Split("eyr:")[1].Substring(0,4);
                    if (a.Length == 4 && Convert.ToInt32(a) >= 2020 && Convert.ToInt32(a) <= 2030)
                    {
                        eyr = true;
                    }
                }
                if (input[i].Contains("hgt"))
                {
                    string a = input[i].Split("hgt:")[1];
                    if (a.Contains("cm"))
                    {
                        string b = a.Split("cm")[0];
                        if (b.Length == 3 && Convert.ToInt32(b) >= 150 && Convert.ToInt32(b) <= 193)
                        {
                            hgt = true;
                        }
                    }
                    else if (a.Contains("in"))
                    {
                        string b = a.Split("in")[0];
                        if (b.Length == 2 && Convert.ToInt32(b) >= 59 && Convert.ToInt32(b) <= 76)
                        {
                            hgt = true;
                        }
                    }
                }
                if (input[i].Contains("hcl"))
                {
                    string a = input[i].Split("hcl:")[1];
                    if (a.Length > 7)
                    {
                        a = a.Substring(0,7);
                    }
                    if (a[0].Equals('#') && a.Length >= 7)
                    {
                        string b = a.Remove(0,1);
                        if (true)
                        {
                            hcl = true;
                        }
                    }
                }
                if (input[i].Contains("ecl"))
                {
                    string a = input[i].Split("ecl:")[1];
                    if (a.Length > 3)
                    {
                        a = a.Substring(0,3);
                    }
                    if (a.ContainsAny("amb","blu","brn","gry","grn","hzl","oth"))
                    {
                        ecl = true;
                    }
                }
                if (input[i].Contains("pid"))
                {
                    string a = input[i].Split("pid:")[1];
                    //System.Console.WriteLine(i);
                    if (a.Length > 9)
                    {
                        if (a[9].Equals(' '))
                        {
                            a = a.Substring(0,9);
                        }
                    }
                    if (a.Length >= 9 && int.TryParse(a, out int n))
                    {
                        pid = true;
                    }
                }
            }
            if (byr == true && iyr == true && eyr == true && hgt == true && hcl == true && ecl == true && pid == true)
                    {
                        validCount++;
                        //System.Console.WriteLine("Last line");
                    }

            System.Console.WriteLine("Valid passports: " + validCount);
        }

        void InitializeInput()
        {
            var lines = File.ReadLines("./input");
            foreach (string line in lines)
            {
                input.Add(line);
            }
        }
    }
}
