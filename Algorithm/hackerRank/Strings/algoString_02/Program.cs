using System;
using System.Linq;

namespace algoString_02
{
    class Program
    {
        //https://www.hackerrank.com/challenges/strong-password/problem
        static void Main(string[] args)
        {
            string password1 = "Ab1";//=>3
            //string password2 = "#HackerRank";//=>1
            var result = Result.minimumNumber(3, password1);
            System.Console.WriteLine(result);
        }
    }
    class Result
    {
        public static int minimumNumber(int n, string password)
        {
            string specialCharacters = "!@#$%^&*()-+";

            int minNum = 0;
            // Its length is at least 6.
            // It contains at least one digit.
            // It contains at least one lowercase English character.
            // It contains at least one uppercase English character.
            // It contains at least one special character. The special characters are: !@#$%^&*()-+

            if (!password.Any(p => char.IsDigit(p))) minNum++;
            if (!password.Any(p => char.IsLower(p))) minNum++;
            if (!password.Any(p => char.IsUpper(p))) minNum++;
            if (!password.Any(p => specialCharacters.Contains(p))) minNum++;


            return Math.Max(minNum, 6 - password.Length);
        }

    }
}
