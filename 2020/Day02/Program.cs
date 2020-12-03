using System;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ex1());
            Console.WriteLine(ex2());
        }

        public static int ex1()
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            char[] delimitChars = new char[] { ' ', '-', ':' };
            int totalCounter = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] listPass = line.Split(delimitChars);
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

        public static int ex2()
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            char[] delimitChars = new char[] { ' ', '-', ':' };
            int totalCounter = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] listPass = line.Split(delimitChars);
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
