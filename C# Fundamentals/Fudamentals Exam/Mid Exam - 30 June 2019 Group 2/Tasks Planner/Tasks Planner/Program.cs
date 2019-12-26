using System;
using System.Linq;

namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskHours = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArr = input.Split();

                if (inputArr[0] == "Complete")
                {
                    int index = int.Parse(inputArr[1]);

                    bool indexValidate = index >= 0 && index < taskHours.Length;

                    if (indexValidate)
                    {
                        taskHours[index] = 0;
                    }
                }
                else if (inputArr[0] == "Change")
                {
                    int index = int.Parse(inputArr[1]);

                    bool indexValidate = index >= 0 && index < taskHours.Length;

                    if (indexValidate)
                    {
                        taskHours[index] = int.Parse(inputArr[2]);
                    }
                }
                else if (inputArr[0] == "Drop")
                {
                    int index = int.Parse(inputArr[1]);

                    bool indexValidate = index >= 0 && index < taskHours.Length;

                    if (indexValidate)
                    {
                        taskHours[index] = -1;
                    }
                }
                else if (inputArr[1] == "Completed")
                {
                    int count = 0;
                    foreach (var hour in taskHours)
                    {
                        if (hour == 0)
                        {
                            count++;
                        }

                    }
                    Console.WriteLine(count);
                }
                else if (inputArr[1] == "Incomplete")
                {
                    int count = 0;
                    foreach (var hour in taskHours)
                    {
                        if (hour > 0)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(count);
                }
                else if (inputArr[1] == "Dropped")
                {
                    int count = 0;
                    foreach (var hour in taskHours)
                    {
                        if (hour < 0)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(count);
                }

                input = Console.ReadLine();
            }

            foreach (var hour in taskHours)
            {
                if (hour > 0)
                {
                    Console.Write(hour + " ");
                }
            }
        }
    }
}
