using System;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            string[] list = new string[1024];
            int k = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
                list[k++] = line;

            Console.WriteLine(ex1(list, k));
            Console.WriteLine(ex2(list, k));
        }

        public static int ex1(string[] list, int k)
        {
            char[] delimitChars = new char[] { ' ', '-', ':' };
            int totalCounter = 0;
            for (int i = 0; i < k; i++)
            {
                string[] listPass = list[i].Split(delimitChars);
                bool ok = true;
                int min = int.Parse(listPass[0]);
                int max = int.Parse(listPass[1]);
                char condition = char.Parse(listPass[2]);
                int count = 0;

                foreach (char c in listPass[4])
                    if (condition.Equals(c))
                        count++;
                if (min > count || max < count)
                    ok = false;
                if (ok)
                    totalCounter++;
            }
            return totalCounter;
        }
        public static int ex2(string[] list, int k)
        {
            char[] delimitChars = new char[] { ' ', '-', ':' };
            int totalCounter = 0;
            for (int i = 0; i < k; i++)
            {
                string[] listPass = list[i].Split(delimitChars);
                int p1 = int.Parse(listPass[0]);
                int p2 = int.Parse(listPass[1]);
                char condition = char.Parse(listPass[2]);
                if ((listPass[4][p1 - 1].Equals(condition) || listPass[4][p2 - 1].Equals(condition))
                    && !(listPass[4][p1 - 1].Equals(condition) && listPass[4][p2 - 1].Equals(condition)))
                    totalCounter++;
            }
            return totalCounter;
        }
    }
}
