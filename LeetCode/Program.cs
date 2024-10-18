using System;

namespace LeetCode
{
    // easy 67: Даны две двоичные строки a и b, вернуть их сумму в виде двоичной строки.
    // ref:  https://leetcode.com/problems/add-binary/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("11", "1"));
            Console.ReadKey();
        }

        static string AddBinary(string a, string b)
        {
            if (a.Length != b.Length)
            {
                var countZeros = Math.Abs(a.Length - b.Length);

                if (a.Length < b.Length)
                    a = new string('0', countZeros) + a;
                else if (b.Length < a.Length)
                    b = new string('0', countZeros) + b;
            }

            var result = Sum(a, b);

            return result.transfer
                ? "1" + result.result
                : result.result;
        }

        static (string result, bool transfer) Sum(string a, string b)
        {
            if (a.Length == 1)
                return Concat(a, b, false);

            var sum = Sum(CutFirstChar(a), CutFirstChar(b));

            var concat = Concat(GetFirstChar(a), GetFirstChar(b), sum.transfer);

            return (concat.result + sum.result, concat.transfer);
            string CutFirstChar(string str) => str.Substring(1, str.Length - 1);
            string GetFirstChar(string str) => str[0].ToString();
        }

        static (string result, bool transfer) Concat(string a, string b, bool add)
        {
            if (add)
            {
                if (a == "1" && b == "1")
                    return ("1", true);
                else if (a == "0" && b == "0")
                    return ("1", false);

                return ("0", true);
            }
            else
            {
                if (a == "1" && b == "1")
                    return ("0", true);
                else if (a == "0" && b == "0")
                    return ("0", false);

                return ("1", false);
            }
        }
    }
}