using System;
using System.Collections.Generic;
using System.Linq;

namespace algoString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "beabeefeab";

            Console.WriteLine(Result.alternate(s));

        }
        public static class Result
        {
            public static int alternate(string s)//"beabeefeab"
            {
                var originalArray = s.ToCharArray().ToList();//{'b','e','a','b','e','e','f','e','a','b'}
                var stringLengths = new List<int>();

                var distinctChars = originalArray.Distinct().ToList();//{'b','e','a','f'}

                for (var i = 0; i < distinctChars.Count - 1; i++)//distinctChars[i]=>{'b','e','a'}
                {
                    for (var j = i + 1; j < distinctChars.Count; j++)//distinctChars[j]=>{'e','a','f'}
                    {
                        var removedChar = originalArray.Where(p => p == distinctChars[i] || p == distinctChars[j]).ToList();
                        var twoCharString = string.Concat(removedChar);
                        Console.WriteLine(twoCharString); //i=0,j=1=>"bebeeeb"              
                        var dups = twoCharString.Contains($"{distinctChars[i]}{distinctChars[i]}")//bebeeeb<=bb =>false
                            || twoCharString.Contains($"{distinctChars[j]}{distinctChars[j]}");//bebeeeb<=ee =>true

                        if (!dups)
                            stringLengths.Add(twoCharString.Length);
                    }
                }

                return stringLengths.Count > 0 ? stringLengths.Max() : 0;
            }
        }
    }
}
