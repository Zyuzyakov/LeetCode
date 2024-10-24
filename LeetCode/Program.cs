using System;

namespace LeetCode
{
    // medium 74: Поиск в двумерной матрице.
    // Вам дана m x nцелочисленная матрица matrixсо следующими двумя свойствами:
    //  -Каждая строка сортируется в неубывающем порядке.
    //  -Первое целое число каждой строки больше последнего целого числа предыдущей строки.
    // Дано целое число target, вернуть, true если target оно находится в пределах matrix , false в противном случае — в пределах .
    // Вам необходимо написать решение по O(log(m* n))временной сложности.
    // ref: https://leetcode.com/problems/search-a-2d-matrix/description/
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 3));
            Console.ReadKey();
        }

        static bool SearchMatrix(int[][] matrix, int target)
        {
            return false;
        }
    }
}