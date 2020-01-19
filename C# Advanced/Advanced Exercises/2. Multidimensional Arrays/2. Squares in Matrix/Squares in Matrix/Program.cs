using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new string[rowAndCol[0], rowAndCol[1]];

            var count = 0;

            FillMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {

                    var firstChar = matrix[row, col];
                    if (matrix[row, col + 1] == firstChar && matrix[row + 1, col] == firstChar && matrix[row + 1, col + 1] == firstChar)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }
        }
    }
}
