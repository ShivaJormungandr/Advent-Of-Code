using System;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            string[] list = new string[512];
            int k = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
                list[k++] = line;

            Console.WriteLine(ex1(list, k, 3, 1));
            Console.WriteLine(ex2(list, k));
        }

        public static int ex1(string[] list, int k, int right, int down)
        {
            int poz = 0;
            int countTrees = 0;
            for (int i = 0 + down; i < k; i += down)
            {
                if (list[i][(poz + right) % 31].Equals('#'))
                    countTrees++;
                poz = (poz + right) % 31;
            }

            return countTrees;
        }

        public static Int64 ex2(string[] list, int k)
        {
            Int64 prod = 1;
            for (int right = 1; right <= 7; right += 2)
                prod *= ex1(list, k, right, 1);
            prod *= ex1(list, k, 1, 2);

            return prod;
        }
    }
}
