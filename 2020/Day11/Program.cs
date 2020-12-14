using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        static void PartOne()
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            List<string> rows = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                rows.Add(line);
            }
            sr.Close();
            List<string> rowsCopy = rows.ToList();
            List<char> adjacent = new List<char>();
            bool same = false;
            while (!same)
            {
                rows = rowsCopy.ToList();
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < rows[i].Length; j++)
                    {
                        if (i - 1 >= 0 && j - 1 >= 0)
                            adjacent.Add(rows[i - 1][j - 1]);
                        if (j - 1 >= 0)
                            adjacent.Add(rows[i][j - 1]);
                        if (i + 1 < rows.Count && j - 1 >= 0)
                            adjacent.Add(rows[i + 1][j - 1]);
                        if (i - 1 >= 0)
                            adjacent.Add(rows[i - 1][j]);
                        if (i + 1 < rows.Count)
                            adjacent.Add(rows[i + 1][j]);
                        if (i - 1 >= 0 && j + 1 < rows[i].Length)
                            adjacent.Add(rows[i - 1][j + 1]);
                        if (j + 1 < rows[i].Length)
                            adjacent.Add(rows[i][j + 1]);
                        if (i + 1 < rows.Count && j + 1 < rows[i].Length)
                            adjacent.Add(rows[i + 1][j + 1]);

                        if (rows[i][j] == 'L')
                        {
                            if (!adjacent.Exists(x => x == '#'))
                            {
                                rowsCopy[i] = ReplaceAtIndex(j, '#', rowsCopy[i]);
                            }
                        }
                        else if (rows[i][j] == '#')
                        {
                            int countOccupied = 0;
                            foreach (char a in adjacent)
                            {
                                if (a == '#')
                                {
                                    countOccupied++;
                                }
                            }
                            if (countOccupied > 3)
                            {
                                rowsCopy[i] = ReplaceAtIndex(j, 'L', rowsCopy[i]);
                            }
                        }
                        adjacent.Clear();
                    }
                }
                same = true;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (!rows[i].Equals(rowsCopy[i]))
                    {
                        same = false;
                    }
                }
            }

            int countFinal = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == '#')
                    {
                        countFinal++;
                    }
                }
            }
            Console.Out.WriteLine(countFinal);
        }
        static void PartTwo()
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            List<string> rows = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                rows.Add(line);
            }
            sr.Close();
            List<string> rowsCopy = rows.ToList();
            List<char> seen = new List<char>();
            bool same = false;
            while (!same)
            {
                rows = rowsCopy.ToList();
                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < rows[i].Length; j++)
                    {

                        for (int k = 1; i - k >= 0 && j - k >= 0; k++)
                        {
                            if (rows[i - k][j - k] != '.')
                            {
                                seen.Add(rows[i - k][j - k]);
                                break;
                            }

                        }
                        for (int k = 1; j - k >= 0; k++)
                        {
                            if (rows[i][j - k] != '.')
                            {
                                seen.Add(rows[i][j - k]);
                                break;
                            }
                        }
                        for (int k = 1; i + k < rows.Count && j - k >= 0; k++)
                        {
                            if (rows[i + k][j - k] != '.')
                            {
                                seen.Add(rows[i + k][j - k]);
                                break;
                            }
                        }
                        for (int k = 1; i - k >= 0; k++)
                        {
                            if (rows[i - k][j] != '.')
                            {
                                seen.Add(rows[i - k][j]);
                                break;
                            }
                        }
                        for (int k = 1; i + k < rows.Count; k++)
                        {
                            if (rows[i + k][j] != '.')
                            {
                                seen.Add(rows[i + k][j]);
                                break;
                            }
                        }
                        for (int k=1; i - k >= 0 && j + k < rows[i].Length; k++)
                        {
                            if (rows[i - k][j + k] != '.')
                            {
                                seen.Add(rows[i - k][j + k]);
                                break;
                            }
                        }
                        for (int k =1; j + k < rows[i].Length; k++)
                        {
                            if (rows[i][j + k] != '.')
                            {
                                seen.Add(rows[i][j + k]);
                                break;
                            }
                        }
                        for (int k = 1; i + k < rows.Count && j + k < rows[i].Length; k++)
                        {
                            if (rows[i + k][j + k] != '.')
                            {
                                seen.Add(rows[i + k][j + k]);
                                break;
                            }
                        }
                        if (rows[i][j] == 'L')
                        {
                            if (!seen.Exists(x => x == '#'))
                            {
                                rowsCopy[i] = ReplaceAtIndex(j, '#', rowsCopy[i]);
                            }
                        }
                        else if (rows[i][j] == '#')
                        {
                            int countOccupied = 0;
                            foreach (char a in seen)
                            {
                                if (a == '#')
                                {
                                    countOccupied++;
                                }
                            }
                            if (countOccupied > 4)
                            {
                                rowsCopy[i] = ReplaceAtIndex(j, 'L', rowsCopy[i]);
                            }
                        }
                        seen.Clear();
                    }
                }
                same = true;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (!rows[i].Equals(rowsCopy[i]))
                    {
                        same = false;
                    }
                }
            }

            int countFinal = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == '#')
                    {
                        countFinal++;
                    }
                }
            }
            Console.Out.WriteLine(countFinal);
        }
        static string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }
    }
}
