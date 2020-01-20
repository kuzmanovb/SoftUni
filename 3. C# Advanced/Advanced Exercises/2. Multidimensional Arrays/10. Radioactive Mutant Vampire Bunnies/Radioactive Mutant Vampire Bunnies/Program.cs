using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new char[rowAndCol[0], rowAndCol[1]];
            var startRow = 0;
            var startCol = 0;
            // Fill matrix and find start position
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                        matrix[row, col] = '.';
                    }
                }
            }

            bool checkForWon = false;
            var commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                BunnySpread(matrix);

                if (commands[i] == 'R')
                {
                    startCol += 1;
                    if (startCol > matrix.GetLength(1) - 1)
                    {
                        startCol -= 1;
                        checkForWon = true;
                        break;
                    }

                }
                else if (commands[i] == 'L')
                {
                    startCol -= 1;
                    if (startCol-1 < 0)
                    {
                        startCol += 1;
                        checkForWon = true;
                        break;
                    }
                }
                else if (commands[i] == 'U')
                {
                    startRow -= 1;
                    if (startRow < 0)
                    {
                        startRow += 1;
                        checkForWon = true;
                        break;
                    }
                }
                else if (commands[i] == 'D')
                {
                    startRow += 1;
                    if (startRow > matrix.GetLength(0) - 1)
                    {
                        startRow -= 1;
                        checkForWon = true;
                        break;
                    }
                }

                if (matrix[startRow, startCol] == 'B')
                {
                    break;
                }

            }

            PrintMatrix(matrix);

            if (checkForWon)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
            else
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }

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

        private static void BunnySpread(char[,] matrix)
        {
            var indexBunny = new List<int[]>();
            FindIndexBunny(matrix, indexBunny);

            foreach (var index in indexBunny)
            {
                var curentRow = index[0];
                var curentCol = index[1];

                if (curentRow - 1 >= 0)
                {
                    matrix[curentRow - 1, curentCol] = 'B';
                }
                if (curentCol - 1 >= 0)
                {
                    matrix[curentRow, curentCol - 1] = 'B';
                }
                if (curentCol + 1 < matrix.GetLength(1))
                {
                    matrix[curentRow, curentCol + 1] = 'B';
                }
                if (curentRow + 1 < matrix.GetLength(0))
                {
                    matrix[curentRow + 1, curentCol] = 'B';
                }
            }
        }

        private static void FindIndexBunny(char[,] matrix, List<int[]> indexBunny)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        indexBunny.Add(new int[] { row, col });
                    }

                }
            }
        }
    }
}
