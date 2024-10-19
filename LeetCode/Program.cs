using System;

namespace LeetCode
{
    // hard 32: Для данной строки, содержащей только символы '(' и ')', вернуть длину самых длинных допустимых (правильно сформированных) скобок.
    // ref: https://leetcode.com/problems/longest-valid-parentheses/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LongestValidParentheses(")()())()()("));
            Console.ReadKey();
        }

        static int LongestValidParentheses(string s)
        {
            int bestParenthesesCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    var parentheses = new SequenceParentheses();

                    for (int j = i; j < s.Length; j++)
                    {
                        parentheses.AddParenthesis(s[j]);

                        if (parentheses.IsBad)
                            break;

                        if (parentheses.IsValid && parentheses.CountChars > bestParenthesesCount)
                            bestParenthesesCount = parentheses.CountChars;
                    }
                }
            }

            return bestParenthesesCount;
        }

        private class SequenceParentheses
        {
            public int CountChars { get => _open + _close; }
            public bool IsValid { get => _open == _close; }
            public bool IsBad { get => _open < _close; }

            private int _open;
            private int _close;

            public void AddParenthesis(char parenthesis)
            {
                if (parenthesis == '(')
                    _open++;
                else
                    _close++;
            }
        }
    }
}