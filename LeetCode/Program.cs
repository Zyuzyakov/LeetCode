using System;

namespace LeetCode
{
    // easy 35: Дано отсортированное множество различных целых чисел и целевое значение, вернуть индекс, если цель найдена.
    // Если нет, вернуть индекс, где бы он был, если бы он был вставлен по порядку.
    // Вам необходимо написать алгоритм, обладающий  O(log n)сложностью во время выполнения.
    // ref: https://leetcode.com/problems/search-insert-position/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(SearchInsert([3, 4, 5, 6, 7, 8], 6)); // 3
            Console.ReadKey();
        }

        static int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 1)
                return nums[0] >= target ? 0 : 1;

            return SearchInsert(nums, target, 0, nums.Length - 1);
        }

        static int SearchInsert(int[] nums, int target, int startIndex, int endIndex)
        {
            if ((endIndex - startIndex) < 2)
            {
                if (nums[startIndex] >= target)
                    return startIndex;

                if (target <= nums[endIndex])
                    return endIndex;

                return endIndex + 1;
            }

            var middleIndex = startIndex + (endIndex - startIndex) / 2;

            if (nums[middleIndex] >= target)
                return SearchInsert(nums, target, startIndex, middleIndex - 1);
            else
                return SearchInsert(nums, target, middleIndex + 1, endIndex);
        }
    }
}