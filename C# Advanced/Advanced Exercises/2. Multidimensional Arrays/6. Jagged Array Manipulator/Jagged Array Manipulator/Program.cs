using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var jaggedArray = new double[rows][];

            FillArray(rows, jaggedArray);

            AnalyzingArray(rows, jaggedArray);

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }
                
                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);
                var value = int.Parse(command[3]);

                bool checkIndex = row >= 0 && row < jaggedArray.Length
                               && col >= 0 && col < jaggedArray[row].Length;

                if (command[0] == "Add" && checkIndex)
                {

                    jaggedArray[row][col] += value;
                }
                else if (command[0] == "Subtract" && checkIndex)
                {
                     
                    jaggedArray[row][col] -= value;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }

        private static void AnalyzingArray(int rows, double[][] jaggedArray)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
        }

        private static void FillArray(int rows, double[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArray[row] = new double[input.Length];
                jaggedArray[row] = input;
            }
        }
    }
}
