using System;
using System.Collections.Generic;
using System.IO;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ex1(true));
            Console.WriteLine(ex2(true));
        }

        public static int ex1(bool ignoreCid)
        {
            int validPass = 0;
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            char[] delimitChars = new char[] { ' ', ':' };
            string[] passport = new string[8];
            List<string> listPass = new List<string>();
            string line;
            int countPassLines = 0;
            bool[] ok = new bool[8];            //byr, iyr, eyr, hgt, hcl, ecl, pid, cid
            Array.Fill<bool>(ok, false);
            while (sr.Peek() > -1)
            {
                while ((line = sr.ReadLine()) != "")
                {
                    passport[countPassLines] = line;
                    countPassLines++;
                    if (line == null)
                    {
                        break;
                    }
                }
                countPassLines = 0;
                foreach (var passLine in passport)
                {
                    if (passLine != null)
                    {
                        foreach (var entry in passLine.Split(delimitChars))
                        {
                            listPass.Add(entry);
                        }
                    }
                }
                foreach (var entry in listPass)
                {
                    switch (entry)
                    {
                        case "byr":
                            ok[0] = true;
                            break;
                        case "iyr":
                            ok[1] = true;
                            break;
                        case "eyr":
                            ok[2] = true;
                            break;
                        case "hgt":
                            ok[3] = true;
                            break;
                        case "hcl":
                            ok[4] = true;
                            break;
                        case "ecl":
                            ok[5] = true;
                            break;
                        case "pid":
                            ok[6] = true;
                            break;
                        case "cid":
                            ok[7] = true;
                            break;
                        default:
                            break;
                    }
                }
                if (ignoreCid == true)
                {
                    ok[7] = true; //set cid as ok even if doesn't exists
                }
                if (Array.TrueForAll<bool>(ok, value => { return value; }))
                {
                    validPass++;
                }
                Array.Fill<bool>(ok, false);
                Array.Fill<string>(passport, "");
                listPass.Clear();
            }

            return validPass;
        }
        public static int ex2(bool ignoreCid)
        {
            int validPass = 0;
            StreamReader sr = new StreamReader(@"..\..\..\in.txt");
            char[] delimitChars = new char[] { ' ', ':' };
            string[] passport = new string[8];
            List<string> listPass = new List<string>();
            string line;
            int countPassLines = 0;
            bool[] ok = new bool[8];            //byr, iyr, eyr, hgt, hcl, ecl, pid, cid
            Array.Fill<bool>(ok, false);
            while (sr.Peek() > -1)
            {
                while ((line = sr.ReadLine()) != "")
                {
                    passport[countPassLines] = line;
                    countPassLines++;
                    if (line == null)
                    {
                        break;
                    }
                }
                countPassLines = 0;
                foreach (var passLine in passport)
                {
                    if (passLine != null)
                    {
                        foreach (var entry in passLine.Split(delimitChars))
                        {
                            listPass.Add(entry);
                        }
                    }
                }
                using (var enumerator = listPass.GetEnumerator())
                {
                    string entry;
                    while (enumerator.MoveNext())
                    {
                        entry = enumerator.Current;
                        switch (entry)
                        {
                            case "byr":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidBirthYear(entry))
                                {
                                    ok[0] = true;
                                }
                                break;
                            case "iyr":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidIssueYear(entry))
                                {
                                    ok[1] = true;
                                }
                                break;
                            case "eyr":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidExpirationYear(entry))
                                {
                                    ok[2] = true;
                                }
                                break;
                            case "hgt":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidHeight(entry))
                                {
                                    ok[3] = true;
                                }
                                break;
                            case "hcl":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidHairColor(entry))
                                {
                                    ok[4] = true;
                                }
                                break;
                            case "ecl":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidEyeColor(entry))
                                {
                                    ok[5] = true;
                                }
                                break;
                            case "pid":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                if (IsValidPID(entry))
                                {
                                    ok[6] = true;
                                }
                                break;
                            case "cid":
                                enumerator.MoveNext();
                                entry = enumerator.Current;
                                ok[7] = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (ignoreCid == true)
                {
                    ok[7] = true; //set cid as ok even if doesn't exists
                }
                if (Array.TrueForAll<bool>(ok, value => { return value; }))
                {
                    validPass++;
                }
                Array.Fill<bool>(ok, false);
                Array.Fill<string>(passport, "");
                listPass.Clear();
            }
            return validPass;
        }
        private static bool IsValidBirthYear(string year)
        {
            int minBirthYear = 1920, maxBirthYear = 2002;
            int birthYear = int.Parse(year);
            if (birthYear >= minBirthYear && birthYear <= maxBirthYear)
            {
                return true;
            }
            return false;
        }
        private static bool IsValidIssueYear(string year)
        {
            int minIssueYear = 2010, maxIssueYear = 2020;
            int issueYear = int.Parse(year);
            if (issueYear >= minIssueYear && issueYear <= maxIssueYear)
            {
                return true;
            }
            return false;
        }
        private static bool IsValidExpirationYear(string year)
        {
            int minExpirationYear = 2020, maxExpirationYear = 2030;
            int expirationYear = int.Parse(year);
            if (expirationYear >= minExpirationYear && expirationYear <= maxExpirationYear)
            {
                return true;
            }
            return false;
        }
        private static bool IsValidHeight(string height)
        {
            int minHeightCm = 150, maxHeightCm = 193, minHeightIn = 59, maxHeightIn = 76;
            if (height.EndsWith("in"))
            {
                int heihgt = int.Parse(height.Substring(0, height.Length - 2));
                if (heihgt >= minHeightIn && heihgt <= maxHeightIn)
                {
                    return true;
                }
            }
            else if (height.EndsWith("cm"))
            {
                int heihgt = int.Parse(height.Substring(0, height.Length - 2));
                if (heihgt >= minHeightCm && heihgt <= maxHeightCm)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsValidHairColor(string color)
        {
            int ok = 0;
            if (color.Substring(0, 1).Equals("#"))
            {
                string colorM = color.Substring(1, color.Length - 1);
                if (colorM.Length == 6)
                {
                    foreach (char c in colorM)
                    {
                        if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'))
                        {
                            ok++;
                        }
                    }
                    if (ok == colorM.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool IsValidEyeColor(string color)
        {
            string[] validEyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return Array.Exists(validEyeColors, element => element == color);
        }
        private static bool IsValidPID(string pid)
        {
            if (pid.Length == 9)
            {
                int ok = 0;
                foreach (char c in pid)
                {
                    if (c >= '0' && c <= '9')
                    {
                        ok++;
                    }
                }
                if (ok == pid.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}