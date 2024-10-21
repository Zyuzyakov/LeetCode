using System;
using System.Collections.Generic;

namespace LeetCode
{
    // hard 32: Для данной строки, содержащей только символы '(' и ')', вернуть длину самых длинных допустимых (правильно сформированных) скобок.
    // ref: https://leetcode.com/problems/longest-valid-parentheses/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            string sample = "((()()";
            Console.WriteLine(sample);
            Console.WriteLine(LongestValidParentheses(sample));
            Console.ReadKey();
        }

        static int LongestValidParentheses(string s)
        {
            const char open = '(';

            int max = 0;
            var stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == open)
                    stack.Push(i);
                else
                {
                    stack.TryPop(out int pop);
                    if (stack.Count == 0)
                        stack.Push(i);
                    else
                        max = Math.Max(max, i - stack.Peek());
                }
            }

            return max;
        }
    }
}