using System;
using System.Collections.Generic;
using System.IO;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumAny = 0;
            int sumAll = 0;
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            int[] ansAllYes = new int[26];
            Array.Fill<int>(ansAllYes, 0);
            int countGroupMembers = 0;
            while (sr.Peek() > -1)
            {
                string line;
                string ans = "";
                while ((line = sr.ReadLine()) != "")
                {
                    ans += line;
                    countGroupMembers++;
                    if (line == null)
                    {
                        countGroupMembers--;
                        break;
                    }
                }
                foreach (char c in ans)
                {
                    ansAllYes[(int)(c - 'a')] += 1;
                }
                foreach (int entry in ansAllYes)
                {
                    if (entry == countGroupMembers)
                    {
                        sumAll++;
                    }
                    if (entry > 0)
                    {
                        sumAny++;
                    }
                }
                countGroupMembers = 0;
                Array.Fill<int>(ansAllYes, 0);
            }

            Console.WriteLine(sumAny);
            Console.WriteLine(sumAll);
        }
    }
}