using System;
using System.Linq;

namespace Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCell = Console.ReadLine().Split('#').ToArray();
            int water = int.Parse(Console.ReadLine());
            int usedWater = 0;
            double effort = 0;


            string[] cellPutOut = new string[inputCell.Length];

            for (int i = 0; i < inputCell.Length; i++)
            {
                string[] cell = inputCell[i].Split(" = ").ToArray();

                int cellValue = int.Parse(cell[1]);

                if (cell[0] == "High" && cellValue >= 81 && cellValue <= 125 && water >= cellValue)
                {
                    cellPutOut[i] = " - " + cellValue;
                    water -= cellValue;
                    effort += cellValue / 4.0;
                    usedWater += cellValue;
                }
                else if (cell[0] == "Medium" && cellValue >= 51 && cellValue <= 80 && water >= cellValue)
                {
                    cellPutOut[i] = " - " + cellValue;
                    water -= cellValue;
                    effort += cellValue / 4.0;
                    usedWater += cellValue;
                }
                else if (cell[0] == "Low" && cellValue >= 1 && cellValue <= 50 && water >= cellValue)
                {
                    cellPutOut[i] = " - " + cellValue;
                    water -= cellValue;
                    effort += cellValue / 4.0;
                    usedWater += cellValue;
                }
                else
                {
                    cellPutOut[i] = "-";
                }
            }

            Console.WriteLine("Cells:");
            for (int a = 0; a < cellPutOut.Length; a++)
            {
                int chek = cellPutOut[a].Length;

                if (chek > 3)
                {
                    Console.WriteLine(cellPutOut[a]);
                }
            }

            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {usedWater}");
        }
    }
}
