using System;

namespace LeetCode
{
    // medium 74: Поиск в двумерной матрице.
    // Вам дана m x nцелочисленная матрица matrix со следующими двумя свойствами:
    //  -Каждая строка сортируется в неубывающем порядке.
    //  -Первое целое число каждой строки больше последнего целого числа предыдущей строки.
    // Дано целое число target, вернуть, true если target находится в пределах matrix, в противном случае false.
    // Вам необходимо написать решение по O(log(m * n))временной сложности.
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
            int lineEndIndex = matrix[0].Length - 1;
            int startLine = 0;
            int endLine = matrix.Length - 1;
            int middleLine = 0;

            if (target < matrix[0][0] || target > matrix[endLine][lineEndIndex])
                return false;

            while (endLine >= startLine)
            {
                middleLine = (startLine + endLine) / 2;
                if (target > matrix[middleLine][lineEndIndex])
                    startLine = middleLine + 1;
                else if (target < matrix[middleLine][0])
                    endLine = middleLine - 1;
                else
                    break;
            }

            var findLine = matrix[middleLine];
            startLine = 0;
            endLine = lineEndIndex;

            while (endLine >= startLine)
            {
                middleLine = (startLine + endLine) / 2;
                if (target == findLine[middleLine])
                    return true;

                if (target > findLine[middleLine])
                    startLine = middleLine + 1;
                else
                    endLine = middleLine - 1;
            }

            return false;
        }
    }
}