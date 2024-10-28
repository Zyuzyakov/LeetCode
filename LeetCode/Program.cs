using System;

namespace LeetCode
{
    // medium 5: Самая длинная палиндромная подстрока.
    // Дана строка s, вернуть самую длинную палиндромную подстроку в s.
    // ref: https://leetcode.com/problems/longest-palindromic-substring/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("xaabacxcabaaxcabaax"));
            Console.WriteLine(_countIn);
            Console.ReadKey();
        }

        static string _maxPalindrome = "";
        static UInt128 _countIn = 0;

        static string LongestPalindrome(string s)
        {
            for (int startIndex = 0; startIndex < s.Length; startIndex++)
            {
                for (int endIndex = startIndex; endIndex < s.Length; endIndex++)
                {
                    _countIn++;

                    int strLength = endIndex - startIndex + 1;
                    var subStr = s.Substring(startIndex, strLength);
                    if (subStr.Length > _maxPalindrome.Length && IsPalindrome(subStr))
                        _maxPalindrome = subStr;
                }
            }

            return _maxPalindrome;
        }

        static bool IsPalindrome(string str)
        {
            int start = 0;
            int end = str.Length - 1;

            while (start <= end)
            {
                if (str[start] != str[end])
                    return false;
                start++;
                end--;
            }

            return true;
        }
    }
}