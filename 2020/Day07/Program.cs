using System;
using System.Collections.Generic;
using System.IO;

namespace Day07
{
    class Program
    {
        static bool[] visited;
        static Dictionary<int, List<(int, int)>> adjacencyList;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            adjacencyList = new Dictionary<int, List<(int, int)>>();
            List<string> colors = new List<string>();
            string[] delimitStrings = new string[] { " bags contain ", " bags, ", " bag, ", " bags.", " bag." };
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] rules = line.Split(delimitStrings, StringSplitOptions.RemoveEmptyEntries);
                colors.Add(rules[0]);
            }
            sr.Close();
            sr = new StreamReader(@"..\..\..\in.txt");
            int countBagsColor = colors.Count;
            while ((line = sr.ReadLine()) != null)
            {
                string[] rules = line.Split(delimitStrings, StringSplitOptions.RemoveEmptyEntries);
                int colorIndex = 0;
                for (int i = 0; i < countBagsColor; i++)
                {
                    if (colors[i].Equals(rules[0]))
                    {
                        colorIndex = i;
                        break;
                    }
                }
                int count = rules.Length;
                adjacencyList[colorIndex] = new List<(int, int)>();
                if (!(rules[1].Substring(0, 2).Equals("no")))
                {
                    for (int j = 1; j < count; j++)
                    {
                        int tempIndex = 0;
                        for (int i = 0; i < countBagsColor; i++)
                        {
                            if (colors[i].Equals(rules[j].Substring(2, rules[j].Length - 2)))
                            {
                                tempIndex = i;
                            }
                        }
                        adjacencyList[colorIndex].Add((tempIndex, int.Parse(rules[j].Substring(0, 1))));
                    }
                }
            }

            visited = new bool[countBagsColor];
            int goldIndex = 0;
            int countBags = 0;
            for (int i = 0; i < countBagsColor; i++)
            {
                if (colors[i].Equals("shiny gold"))
                {
                    goldIndex = i;
                    break;
                }
            }
            for (int i = 0; i < countBagsColor; i++)
            {
                Array.Fill(visited, false);
                DFS(i);
                if (visited[goldIndex])
                {
                    countBags++;
                }
            }
            Console.Out.WriteLine(countBags - 1);
            int allBagsYouNeed = HowManyInBag(goldIndex);
            Console.Out.WriteLine(allBagsYouNeed - 1);

        }

        static void DFS(int at)
        {
            if (visited[at])
                return;
            visited[at] = true;
            var neibourghs = adjacencyList[at];
            for (int i = 0; i < neibourghs.Count; i++)
            {
                DFS(neibourghs[i].Item1);
            }
        }
        static int HowManyInBag(int at)
        {
            int inThisBag = 1;
            var neibourghs = adjacencyList[at];
            for (int i = 0; i < neibourghs.Count; i++)
            {
                inThisBag += HowManyInBag(neibourghs[i].Item1) * neibourghs[i].Item2;
            }
            return inThisBag;
        }
    }
}
