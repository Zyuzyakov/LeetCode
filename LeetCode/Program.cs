using System;
using System.Linq;

namespace LeetCode
{
    // easy 1: Дан массив целых чисел nums и целое число target, вернуть индексы двух чисел, чтобы их сумма давала target.
    // Вы можете предположить, что каждый вход будет иметь ровно одно решение, и вы не можете использовать один и тот же элемент дважды.
    // Можете ли вы придумать алгоритм, сложность которого меньше временной O(n^2).
    // ref: https://leetcode.com/problems/two-sum/
    public static class Program
    {
        public static void Main(string[] args)
        {
            TwoSum([3, 4, 2], 6).Select(i => { Console.WriteLine(i); return i; }).ToArray();
            Console.ReadKey();
        }

        static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if ((nums[i] + nums[j]) == target)
                        return [i, j];

                }
            }

            throw new Exception("Решение не найшлось.");
        }
    }
}