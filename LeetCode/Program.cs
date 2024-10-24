using System;

namespace LeetCode
{
    // easy 704: Двоичный поиск.
    // Дан массив целых чисел nums, отсортированный по возрастанию, и целое число target.
    // Напишите функцию для поиска target в nums. Если target существует, то верните его индекс.
    // В противном случае верните -1.
    // ref: https://leetcode.com/problems/binary-search/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Search([-1, 0, 3, 5, 9, 12], 9));
            Console.ReadKey();
        }

        static int Search(int[] nums, int target)
        {
            int startIndex = 0;
            int endIndex = nums.Length - 1;

            while (endIndex >= startIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                if (nums[middleIndex] == target)
                    return middleIndex;

                if (nums[middleIndex] < target)
                    startIndex = middleIndex + 1;
                else
                    endIndex = middleIndex - 1;
            }

            return -1;
        }
    }
}