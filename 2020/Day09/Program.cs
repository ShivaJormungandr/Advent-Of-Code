using System;
using System.Collections.Generic;
using System.IO;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            LinkedList<long> code = new LinkedList<long>();
            int preamble = 25;
            long invalidNumber = 0;
            int lastRead = preamble;
            string line;
            for (int i = 0; i <= preamble; i++)
            {
                code.AddLast(int.Parse(sr.ReadLine()));
            }
            while ((line = sr.ReadLine()) != null)
            {
                lastRead++;
                bool ok = false;
                foreach (long number in code)
                {
                    long other = long.MaxValue;
                    if (code.Find(code.Last.Value - number) != null)
                    {
                        other = code.Find(code.Last.Value - number).Value;
                    }
                    if (other != number && (other + number == code.Last.Value))
                    {
                        //Console.Out.WriteLine(number + " + " + other + " = " + code.Last.Value);
                        ok = true;
                    }
                }
                if (!ok)
                {
                    Console.Out.WriteLine(code.Last.Value);
                    invalidNumber = code.Last.Value;
                    break;
                }
                code.RemoveFirst();
                code.AddLast(long.Parse(line));
            }
            sr.Close();
            code.Clear();
            sr = new StreamReader(@"..\..\..\in.txt");
            while ((line = sr.ReadLine())!= null && lastRead > 0)
            {
                code.AddLast(long.Parse(line));
                lastRead--;
            }
            long sum = 0;
            while (sum != invalidNumber)
            {
                sum = 0;
                bool ok = false;
                long lastInSet = 0;
                foreach (long number in code)
                {
                    sum += number;
                    if (sum > invalidNumber)
                    {
                        code.RemoveFirst();
                        break;
                    }
                    else if (sum == invalidNumber)
                    {
                        ok = true;
                        lastInSet = number;
                        break;
                    }
                }
                if (ok)
                {
                    while(code.Last.Value > lastInSet)
                    {
                        code.RemoveLast();
                    }
                    break;
                }
            }
            long max = 0;
            long min = long.MaxValue;
            foreach(long number in code)
            {
                if (number < min)
                {
                    min = number;
                }
                if (number > max)
                {
                    max = number;
                }
            }
            Console.Out.WriteLine(min + max);
        }
    }
}
