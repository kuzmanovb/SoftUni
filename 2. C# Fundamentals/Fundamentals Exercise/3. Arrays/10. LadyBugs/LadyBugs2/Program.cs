using System;
using System.Linq;

namespace LadyBugs2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayBugs = new int[int.Parse(Console.ReadLine())];
            
            for (int y = 0; y < arrayBugs.Length; y++)
            {
                arrayBugs[y] = 0;
            }

            int[] indexBugsStart = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < indexBugsStart.Length; i++)
            {
                if (indexBugsStart[i] >= 0 && indexBugsStart[i] < arrayBugs.Length)
                {
                    arrayBugs[indexBugsStart[i]] = 1;
                }
            }

            string input = Console.ReadLine();

            while (input != "end")
            {

                string[] inputArr = input.Split();

                int startIndex = int.Parse(inputArr[0]);
                string direction = inputArr[1];
                int moveCount = int.Parse(inputArr[2]);

                switch (direction)
                {
                    case "right":
                        if (startIndex >= 0 && startIndex < arrayBugs.Length)
                        {
                            MoveRight(startIndex, moveCount, arrayBugs);
                        }
                        break;
                    case "left":
                        if (startIndex >= 0 && startIndex < arrayBugs.Length)
                        {
                            MoveLeft(startIndex, moveCount, arrayBugs);
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", arrayBugs));
        }

        private static void MoveLeft(int startIndex, int moveCount, int[] arrayBugs)
        {
            if (arrayBugs[startIndex] == 1)
            {
                arrayBugs[startIndex] = 0;

                int newIndex = startIndex - moveCount;

                while (newIndex >= 0 && arrayBugs[newIndex] == 1)
                {
                    newIndex -= moveCount;
                }

                if (newIndex >= 0)
                {
                    arrayBugs[newIndex] = 1;
                }
            }
        }

        static void MoveRight(int start, int move, int[] arrayBugs)
        {
            if (arrayBugs[start] == 1)
            {
                arrayBugs[start] = 0;

                int newIndex = start + move;

                while (newIndex < arrayBugs.Length && arrayBugs[newIndex] == 1)
                {
                    newIndex += move;
                }

                if (newIndex < arrayBugs.Length)
                {
                    arrayBugs[newIndex] = 1;
                }
            }
        }
    }
}

