using System;
using System.IO;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            int[] list = new int[256];
            int k = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
                list[k++] = int.Parse(line);

            Console.WriteLine(ex1(list, k));
            Console.WriteLine(ex2(list, k));
        }
        public static int ex1(int[] list, int k)
        {
            for (int i = 0; i < k; i++)
                for (int j = i; j < k; j++)
                    if (list[i] + list[j] == 2020)
                        return (list[i] * list[j]);
            return 0;
        }

        public static int ex2(int[] list, int k)
        {
            for (int i = 0; i < k; i++)
                for (int j = i; j < k; j++)
                    for (int m = j; m < k; m++)
                        if (list[i] + list[j] + list[m] == 2020)
                            return (list[i] * list[j] * list[m]);
            return 0;
        }
    }
}
