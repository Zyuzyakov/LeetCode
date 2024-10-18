using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    // hard 135: Дети n стоят в ряд. Каждому ребенку присваивается рейтинговое значение, указанное в целочисленном массиве ratings.
    // ref: https://leetcode.com/problems/candy/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Candy([1, 2, 87, 87, 87, 2, 1]));
            Console.ReadKey();
        }

        static int Candy(int[] ratings)
        {
            var dict = new Dictionary<string, ushort>();

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    dict.TryGetValue((i - 1).ToString(), out ushort prevValue);

                    dict[i.ToString()] = (ushort)(prevValue + 1);
                }
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    dict.TryGetValue((i + 1).ToString(), out ushort prevValue);

                    dict.TryGetValue(i.ToString(), out ushort iValue);

                    if (iValue <= prevValue)
                        dict[i.ToString()] = (ushort)(prevValue + 1);
                }
            }

            return dict.Sum(x => x.Value) + ratings.Length;
        }
    }
}