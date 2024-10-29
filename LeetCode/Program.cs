using System;

namespace LeetCode
{
    // medium 912: Сортировка массива (quick sort).
    // Дан массив целых чисел nums, отсортируйте массив в порядке возрастания и верните его.
    // Вам необходимо решить задачу, не используя встроенные функции по O(nlog(n)) временной сложности и с минимально возможной пространственной сложностью.
    // ref: https://leetcode.com/problems/sort-an-array/description/
    public static class Program
    {
        private static Random _randomizer = new Random();
        public static void Main(string[] args)
        {
            var array = SortArray([5, 2, 3, 1]);
            Console.WriteLine(string.Join(" ", array));
            Console.ReadKey();
        }

        static int[] SortArray(int[] nums)
        {
            QSort(nums, 0, nums.Length - 1);

            return nums;
        }

        static void QSort(int[] nums, int start, int end)
        {
            if (start >= end)
                return;

            int pivotIndex = _randomizer.Next(start, end + 1);
            var pivotValue = nums[pivotIndex];
            int i = start - 1;
            int j = end + 1;
            while (true)
            {
                do
                    i++;
                while (nums[i] < pivotValue);

                do
                    j--;
                while (nums[j] > pivotValue);

                if (i >= j)
                    break;

                Swap(nums, i, j);
            }

            QSort(nums, start, i - 1);
            QSort(nums, i, end);
        }

        static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}