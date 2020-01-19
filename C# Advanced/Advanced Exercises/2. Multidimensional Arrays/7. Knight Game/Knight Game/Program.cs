using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            var dimensions = int.Parse(Console.ReadLine());

            var matrix = new char[dimensions, dimensions];

            FillMatrix(dimensions, matrix);

            int removeKnight = 0;

            while (true)
            {

                int maxAttack = 0;
                int maxKnightIndexRow = 0;
                int maxKnightIndexCol = 0;
                for (int row = 0; row < dimensions; row++)
                {
                    for (int col = 0; col < dimensions; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int count = 0;
                            count = CheckKnightAttack(dimensions, matrix, count, row - 1, col - 2);
                            count = CheckKnightAttack(dimensions, matrix, count, row - 1, col + 2);
                            count = CheckKnightAttack(dimensions, matrix, count, row - 2, col - 1);
                            count = CheckKnightAttack(dimensions, matrix, count, row - 2, col + 1);
                            count = CheckKnightAttack(dimensions, matrix, count, row + 1, col - 2);
                            count = CheckKnightAttack(dimensions, matrix, count, row + 1, col + 2);
                            count = CheckKnightAttack(dimensions, matrix, count, row + 2, col - 1);
                            count = CheckKnightAttack(dimensions, matrix, count, row + 2, col + 1);

                            if (count > maxAttack)
                            {
                                maxAttack = count;
                                maxKnightIndexRow = row;
                                maxKnightIndexCol = col;
                            }
                        }
                    }
                }

                if (maxAttack == 0)
                {
                    break;
                }
                else
                {
                    matrix[maxKnightIndexRow, maxKnightIndexCol] = '0';
                    removeKnight++;
                }
            }

            Console.WriteLine(removeKnight);

        }

        private static int CheckKnightAttack(int dimensions, char[,] matrix, int count, int row, int col)
        {
            if (CheckIndex(row, col, dimensions))
            {
                if (matrix[row, col] == 'K')
                {
                    count++;
                }
            }

            return count;
        }

        private static void FillMatrix(int dimensions, char[,] matrix)
        {
            for (int row = 0; row < dimensions; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static bool CheckIndex(int row, int col, int dimensions)
        {
            return row >= 0 && row < dimensions && col >= 0 && col < dimensions;

        }
    }
}
