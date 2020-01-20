using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            var rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (rowAndCol[0] >= 3 && rowAndCol[1] >= 3)
            {

                var matrix = new int[rowAndCol[0], rowAndCol[1]];

                FillMatrix(rowAndCol, matrix);

                var maximalSum = int.MinValue;
                var startRow = 0;
                var startCol = 0;

                for (int row = 0; row < rowAndCol[0] - 2; row++)
                {
                    for (int col = 0; col < rowAndCol[1] - 2; col++)
                    {
                        var sumRowFirst = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                        var sumRowTwo = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                        var sumRowThree = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                        var allSum = sumRowFirst + sumRowTwo + sumRowThree;
                        if (allSum > maximalSum)
                        {
                            maximalSum = allSum;
                            startRow = row;
                            startCol = col;
                        }
                    }
                }

                Console.WriteLine($"Sum = {maximalSum}");
                PrintMatrix(matrix, startRow, startCol);
            }

        }

        private static void FillMatrix(int[] rowEndCol, int[,] matrix)
        {
            for (int row = 0; row < rowEndCol[0]; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < rowEndCol[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static void PrintMatrix(int[,] matrix, int startRow, int startCol)
        {
            for (int row = startRow; row <= startRow + 2; row++)
            {
                for (int col = startCol; col <= startCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
