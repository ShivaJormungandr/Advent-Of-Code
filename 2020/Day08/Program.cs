using System;
using System.Collections.Generic;
using System.IO;

namespace Day08
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            List<string> instructions = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                instructions.Add(line);
            }
            sr.Close();
            Console.Out.WriteLine(Execute(instructions, true));
            for (int i = 0; i < (instructions.Count); i++)
            {
                if (instructions[i].StartsWith("jmp"))
                {
                    string original = instructions[i];
                    instructions[i] = "nop" + instructions[i].Substring(3);
                    if (Execute(instructions, false) != int.MaxValue)
                    {
                        Console.Out.WriteLine(Execute(instructions, false));
                    }
                    instructions[i] = original;
                }
                else if (instructions[i].StartsWith("nop"))
                {
                    string original = instructions[i];
                    instructions[i] = "jmp" + instructions[i].Substring(3);
                    if (Execute(instructions, false) != int.MaxValue)
                    {
                        Console.Out.WriteLine(Execute(instructions, false));
                    }
                    instructions[i] = original;
                }
            }
        }

        static int Execute(List<string> instructions, bool part1)
        {
            int listLenght = instructions.Count;
            bool[] executed = new bool[listLenght];
            Array.Fill(executed, false);
            int accumulator = 0;
            int lastExecuted = int.MaxValue;
            for (int i = 0; i < listLenght; i++)
            {

                if (executed[i])
                {
                    break;
                }
                else
                {
                    executed[i] = true;
                    lastExecuted = i;
                    if (instructions[i].StartsWith("acc"))
                    {
                        if (instructions[i][4].Equals('+'))
                        {
                            accumulator += int.Parse(instructions[i].Substring(5));
                        }
                        else if (instructions[i][4].Equals('-'))
                        {
                            accumulator -= int.Parse(instructions[i].Substring(5));
                        }
                    }
                    else if (instructions[i].StartsWith("jmp"))
                    {
                        if (instructions[i][4].Equals('+'))
                        {
                            i += (int.Parse(instructions[i].Substring(5)) - 1);
                        }
                        else if (instructions[i][4].Equals('-'))
                        {
                            i -= (int.Parse(instructions[i].Substring(5)) + 1);
                        }
                    }
                }
            }
            if (lastExecuted == (listLenght - 1) || part1)
            {
                return accumulator;
            }
            return int.MaxValue;
        }
    }
}
