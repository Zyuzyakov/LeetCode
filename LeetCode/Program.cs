using System;
using System.Collections;

namespace LeetCode
{
    // hard 4: Даны два отсортированных массива nums1 и nums2 размером m и n соответственно, вернуть медиану двух отсортированных массивов.
    // Общая сложность времени выполнения должна быть O(log (m+n)).
    // https://leetcode.com/problems/median-of-two-sorted-arrays/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            var result = FindMedianSortedArrays([2], [2]);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (IsExtremeConditions(nums1, nums2, out double result))
                return result;

            var isPairMedian = (nums1.Length + nums2.Length) % 2 == 0;
            var medianIndex = (nums1.Length + nums2.Length) / 2 + 1;

            var leftEnumerator = nums1.GetEnumerator();
            var rightEnumerator = nums2.GetEnumerator();
            leftEnumerator.MoveNext();

            int currentIndex = 0;
            int currentValue = (int)leftEnumerator.Current;
            int prevValue = 0;

            while (currentIndex < medianIndex)
            {
                prevValue = currentValue;

                currentValue = GetSmallerValue(ref leftEnumerator, ref rightEnumerator);

                currentIndex++;
            }

            return isPairMedian ? (double)(currentValue + prevValue) / 2 : currentValue;
        }

        static int GetSmallerValue(ref IEnumerator current, ref IEnumerator second)
        {
            if (second.MoveNext())
            {
                bool currentSmaller = (int)current.Current < (int)second.Current;
                if (currentSmaller)
                {
                    var newSecond = current;
                    current = second;
                    second = newSecond;
                    return (int)newSecond.Current;
                }
                else
                    return (int)second.Current;
            }

            var currentValue = (int)current.Current;
            current.MoveNext();
            return currentValue;
        }

        static bool IsExtremeConditions(int[] nums1, int[] nums2, out double result)
        {
            bool hasEmptyArray = nums1.Length == 0 || nums2.Length == 0;
            if (hasEmptyArray)
            {
                var notEmptyArray = nums1.Length == 0 ? nums2 : nums1;

                var isPairMedian = notEmptyArray.Length % 2 == 0;
                if (isPairMedian)
                {
                    var rightIndex = notEmptyArray.Length / 2;
                    result = (double)(notEmptyArray[rightIndex - 1] + notEmptyArray[rightIndex]) / 2;
                    return true;
                }
                else
                {
                    result = notEmptyArray[notEmptyArray.Length / 2];
                    return true;
                }
            }

            result = 0;
            return false;
        }
    }
}