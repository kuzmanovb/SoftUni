using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[rowAndCol[0], rowAndCol[1]];
            FillMartix(matrix);

            while (true)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }
                else if (command[0] == "swap" && command.Length == 5)
                {
                    SwapEndPrintMatrixOrError(matrix, command);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void SwapEndPrintMatrixOrError(string[,] matrix, string[] command)
        {
            var firstRow = int.Parse(command[1]);
            var firstCol = int.Parse(command[2]);
            var secondRow = int.Parse(command[3]);
            var secondCol = int.Parse(command[4]);

            bool checkIndex = firstRow >= 0 && firstRow < matrix.GetLength(0)
                           && firstCol >= 0 && firstCol < matrix.GetLength(1)
                           && secondRow >= 0 && secondRow < matrix.GetLength(0)
                           && secondCol >= 0 && secondCol < matrix.GetLength(1);
            if (checkIndex)
            {
                var itemFirst = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = itemFirst;

                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        private static void FillMartix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }

            }
        }

        private static void PrintMatrix(string[,] matrix)
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
    }
}
