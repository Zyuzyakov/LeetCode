using System;
using System.Collections.Generic;

namespace LeetCode
{
    // medium 3: Самая длинная подстрока без повторяющихся символов.
    // ref: https://leetcode.com/problems/longest-substring-without-repeating-characters/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLongestSubstring("qrsvbspk")); //qrsvb

            Console.ReadKey();
        }

        static int LengthOfLongestSubstring(string s)
        {
            var queue = new Queue<char>();
            int max = 0;
            int current = 0;

            while (current < s.Length)
            {
                if (!queue.Contains(s[current]))
                {
                    queue.Enqueue(s[current]);
                    max = Math.Max(max, queue.Count);
                    current++;
                }
                else
                {
                    queue.Dequeue();
                }
            }

            return max;
        }
    }
}