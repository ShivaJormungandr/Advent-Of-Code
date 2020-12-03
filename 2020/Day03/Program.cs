using System;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ex1(3, 1));
            Console.WriteLine(ex2());
        }

        public static int ex1(int right, int down)
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            int poz = 0;
            int countTrees = 0;
            string line = sr.ReadLine();
            int countDown = 1;
            while ((line = sr.ReadLine()) != null)
            {
                while (countDown < down)
                {
                    line = sr.ReadLine();
                    countDown++;
                }
                countDown = 1;
                if (line[(poz + right) % line.Length].Equals('#'))
                    countTrees++;
                poz = (poz + right) % line.Length;
            }
            sr.Close();
            return countTrees;
        }

        public static Int64 ex2()
        {
            Int64 prod = 1;
            for (int right = 1; right <= 7; right += 2)
                prod *= ex1(right, 1);
            prod *= ex1(1, 2);

            return prod;
        }
    }
}
