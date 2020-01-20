using System;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var input = Console.ReadLine().ToCharArray();

            var matrix = new char[rowAndCol[0], rowAndCol[1]];
            var countIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = input[countIndex];
                        countIndex++;
                        if (countIndex >= input.Length)
                        {
                            countIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = input[countIndex];
                        countIndex++;
                        if (countIndex >= input.Length)
                        {
                            countIndex = 0;
                        }
                    }
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
