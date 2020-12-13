using System;
using System.Collections.Generic;
using System.IO;

namespace Day10
{
    class Program
    {

        static void Main()
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            List<int> adapters = new List<int>();
            adapters.Add(0);
            int max = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                adapters.Add(int.Parse(line));
                if (int.Parse(line) > max)
                {
                    max = int.Parse(line);
                }
            }
            sr.Close();
            adapters.Sort();
            adapters.Add(max + 3);
            int joltDiffOne = 0;
            int joltDiffTwo = 0;
            int joltDiffThree = 0;
            for (int i = 0; i < adapters.Count - 1; i++)
            {
                if (adapters[i + 1] - adapters[i] == 1)
                {
                    joltDiffOne++;
                }
                else if (adapters[i + 1] - adapters[i] == 2)
                {
                    joltDiffTwo++;
                }
                else if (adapters[i + 1] - adapters[i] == 3)
                {
                    joltDiffThree++;
                }
            }
            Console.Out.WriteLine(joltDiffOne * joltDiffThree);
            Console.Out.WriteLine(pass(adapters, 0));
        }
        static long[] has = new long[102];
        static long pass(List<int> adapters, int i)
        {
            if (i == adapters.Count - 1)
            {
                return 1;
            }
            if (has[i] != 0)
            {
                return has[i];
            }
            long ans = 0;
            for (int j = i + 1; (j < adapters.Count && j < i + 4); j++)
            {
                if (adapters[j] - adapters[i] <= 3)
                {
                    ans += pass(adapters, j);
                }
            }
            has[i] = ans;
            //Console.Out.WriteLine(ans);
            return ans;
        }
    }
}
