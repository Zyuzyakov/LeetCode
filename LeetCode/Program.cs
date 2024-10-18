using System;

namespace LeetCode
{
    // easy 69: Дано неотрицательное целое число x, вернуть квадратный корень x округленного вниз до ближайшего целого числа.
    // ref: https://leetcode.com/problems/sqrtx/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MySqrt(2147395599));
            Console.ReadKey();
        }

        static int MySqrt(int x)
        {
            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            uint val = 1;
            while (true)
            {
                uint next = val + 1;
                if (next * next > x)
                    return (int)val;
                else
                {
                    val = next;
                    continue;
                }
            }
        }
    }
}