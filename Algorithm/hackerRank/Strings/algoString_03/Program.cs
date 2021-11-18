using System;

namespace algoString_03
{
    class Program
    {
        //https://www.hackerrank.com/challenges/caesar-cipher-1/problem
        static void Main(string[] args)
        {
            string s = "www.abc.xy";
            Console.WriteLine(Result.caesarCipher(s, 10));
        }
    }
    class Result
    {
        public static string caesarCipher(string s, int k)
        {
            var realAlphabet = "abcdefghijklmnopqrstuvwxyz";
            var newAlphabet = realAlphabet.Substring(k) + realAlphabet.Substring(0, k);

            string newStr = "";
            foreach (var item in s)
            {
                if (char.IsLower(item))
                {
                    newStr += newAlphabet[realAlphabet.IndexOf(item)];
                }
                else if (char.IsUpper(item))
                {
                    var newItem = newAlphabet[realAlphabet.IndexOf(char.ToLower(item))];
                    newStr += char.ToUpper(newItem);
                }
                else
                {
                    newStr += item;
                }

            }

            return newStr;
        }

    }
}
