using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[sizeMatrix, sizeMatrix];

            var commands = Console.ReadLine().Split();

            var allCoals = 0;
            var rowStart = 0;
            var colStart = 0;
            var rowEnd = 0;
            var colEnd = 0;

            bool check = true;

            // Fill matrix and find all coal, start index and  end index
            for (int row = 0; row < sizeMatrix; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < sizeMatrix; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'c')
                    {
                        allCoals++;
                    }
                    else if (input[col] == 'e')
                    {
                        rowEnd = row;
                        colEnd = col;
                    }
                    else if (input[col] == 's')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                //Find position after command
                if (commands[i] == "up" && rowStart - 1 >= 0)
                {
                    rowStart -= 1;
                }
                else if (commands[i] == "down" && rowStart + 1 < sizeMatrix)
                {
                    rowStart += 1;
                }
                else if (commands[i] == "left" && colStart - 1 >= 0)
                {
                    colStart -= 1;
                }
                else if (commands[i] == "right" && colStart + 1 < sizeMatrix)
                {
                    colStart += 1;
                }

                //Check what is in position
                if (matrix[rowStart, colStart] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowStart}, {colStart})");
                    check = false;
                    break;
                }
                else if (matrix[rowStart, colStart] == 'c')
                {
                    matrix[rowStart, colStart] = '*';
                    allCoals--;
                    if (allCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({rowStart}, { colStart})");
                        check = false;
                        break;
                    }
                }
            }
           
            //Print if coal left
            if (check)
            {
                Console.WriteLine($"{allCoals} coals left. ({rowStart}, {colStart})");
            }

        }
    }
}
