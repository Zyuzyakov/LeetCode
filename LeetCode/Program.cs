using System;

namespace LeetCode
{
    // hard 10: Сопоставление регулярных выражений.
    // Для заданной входной строки s и шаблона реализуйте сопоставление регулярных выражений с поддержкой '.' и '*' где:
    //  - '.'Соответствует любому отдельному символу.
    //  - '*'Соответствует нулю или более предыдущим элементам.
    // Сопоставление должно охватывать всю входную строку (не частично).
    // ref: https://leetcode.com/problems/regular-expression-matching/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsMatch("aa", "a*")); // true
            Console.ReadKey();
        }
        static bool IsMatch(string s, string p)
        {
            return false;
        }
    }
}