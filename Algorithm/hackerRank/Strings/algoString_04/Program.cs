using System;
using System.Collections.Generic;

namespace algoString_04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tests = new List<string>()
            {
                "knarrekcah",
                "hackerrank",
                "hackeronek",
                "abcdefghijklmnopqrstuvwxyz",
                "rhackerank",
                "ahankercka",
                "hacakaeararanaka",
                "hhhhaaaaackkkkerrrrrrrrank",
                "crackerhackerknar",
                "hhhackkerbanker"
            };
            foreach (var item in tests)
            {
                Console.WriteLine(Result.hackerrankInString(item));
            }

        }
    }

    class Result
    {
        public static string hackerrankInString(string s)
        {
            int count = 0;
            string main = "hackerrank";

            for (int i = 0; i < main.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (main[i] == s[j])
                    {
                        count++;
                    }
                }

            }

            return count == 10 ? "YES" : "NO";

        }

    }
}
