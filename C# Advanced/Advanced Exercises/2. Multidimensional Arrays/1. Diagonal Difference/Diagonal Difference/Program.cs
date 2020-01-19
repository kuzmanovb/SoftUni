using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeMatrix, sizeMatrix];
            FillMatrix(sizeMatrix, matrix);

            var sumLeft = 0;
            var sumRight = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumLeft += matrix[i, i];
                sumRight += matrix[i, matrix.GetLength(1) - i - 1];
            }

            Console.WriteLine(Math.Abs(sumLeft - sumRight));
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
    }
}
