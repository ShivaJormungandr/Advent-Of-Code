using System;
using System.IO;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxRows = 127, maxColums = 7;
            int maxSeat = 0, minSeat = (maxRows * 8 + maxColums);
            bool[,] allSeats = new bool[maxRows + 1, maxColums + 1];
            for (int i = 0; i <= maxRows; i++)
            {
                for (int j = 0; j <= maxColums; j++)
                {
                    allSeats[i, j] = false;
                }
            }

            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                int minCurrentRow = 0, maxCurrentRow = maxRows;
                int minCurrentColumn = 0, maxCurretColumn = maxColums;
                foreach (char c in line)
                {
                    if (c.Equals('F'))
                    {
                        maxCurrentRow = maxCurrentRow / 2 + minCurrentRow / 2;
                    }
                    else if (c.Equals('B'))
                    {
                        minCurrentRow = maxCurrentRow / 2 + minCurrentRow / 2 + 1;
                    }
                    else if (c.Equals('L'))
                    {
                        maxCurretColumn = maxCurretColumn / 2 + minCurrentColumn / 2;
                    }
                    else if (c.Equals('R'))
                    {
                        minCurrentColumn = maxCurretColumn / 2 + minCurrentColumn / 2 + 1;
                    }
                }
                int curentSeat = maxCurrentRow * 8 + maxCurretColumn;
                allSeats[maxCurrentRow, maxCurretColumn] = true;
                if (curentSeat > maxSeat)
                {
                    maxSeat = curentSeat;
                }
                if (curentSeat < minSeat)
                {
                    minSeat = curentSeat;
                }
            }

            Console.WriteLine(maxSeat);

            bool ok = false;
            for (int i = 0; i <= maxRows; i++)
            {
                for (int j = 0; j <= maxColums; j++)
                {
                    if ((i * 8 + j) > minSeat && (i * 8 + j) < maxSeat && allSeats[i, j] == false)
                    {
                        Console.WriteLine(i * 8 + j);
                        ok = true;
                        break;
                    }
                }
                if (ok)
                {
                    break;
                }
            }

        }

    }
}
