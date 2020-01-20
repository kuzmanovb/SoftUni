using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeMatrix, sizeMatrix];
            FillMatrix(sizeMatrix, matrix);

            var indexBombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < indexBombs.Length; i++)
            {
                var curentRowEndCol = indexBombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (CheckIndex(matrix, curentRowEndCol[0], curentRowEndCol[1]))
                {
                    var row = curentRowEndCol[0];
                    var col = curentRowEndCol[1];
                    var bombValue = matrix[row, col];
                    if (bombValue > 0)
                    {
                        demageCell(matrix, bombValue, row - 1, col - 1);
                        demageCell(matrix, bombValue, row - 1, col);
                        demageCell(matrix, bombValue, row - 1, col + 1);
                        demageCell(matrix, bombValue, row, col - 1);
                        demageCell(matrix, bombValue, row, col + 1);
                        demageCell(matrix, bombValue, row + 1, col - 1);
                        demageCell(matrix, bombValue, row + 1, col);
                        demageCell(matrix, bombValue, row + 1, col + 1);
                        matrix[row, col] = 0;
                    }
                }

            }

            var aliveCells = 0;
            var sumCells = 0;
            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    sumCells += cell;
                    aliveCells++;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumCells}");
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void FillMatrix(int sizeMatrix, int[,] matrix)
        {
            for (int row = 0; row < sizeMatrix; row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static bool CheckIndex(int[,] matrix, int row, int col)
        {

            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
        private static void demageCell(int[,] matrix, int bombValue, int row, int col)
        {
            if (CheckIndex(matrix, row, col) && matrix[row, col] > 0)
            {
                matrix[row, col] -= bombValue;
            }
        }
    }
}
