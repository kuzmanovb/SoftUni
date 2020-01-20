using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string comand = Console.ReadLine();

            while (comand != "END")
            {
                if (comand == "END")
                {
                    break;
                }

                string[] comandArray = comand.Split(' ').ToArray();

                if (comandArray[0] == "Change")
                {
                    int paintingNumber = int.Parse(comandArray[1]);
                    int changedNumber = int.Parse(comandArray[2]);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] == paintingNumber)
                        {
                            input.RemoveAt(i);
                            input.Insert(i, changedNumber);
                            break;
                        }
                    }
                }
                else if (comandArray[0] == "Hide")
                {
                    int paintingNumber = int.Parse(comandArray[1]);

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] == paintingNumber)
                        {
                            input.RemoveAt(i);
                            break;
                        }
                    }
                }
                else if (comandArray[0] == "Switch")
                {
                    int paintingNumber = int.Parse(comandArray[1]);
                    int paintingNumber2 = int.Parse(comandArray[2]);

                    int start = 0;
                    int index1 = -1;
                    int index2 = -1;

                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] == paintingNumber && index1 == -1)
                        {
                            index1 = i;
                            start++;
                        }
                        else if (input[i] == paintingNumber2 && index2 == -1)
                        {
                            index2 = i;
                            start++;
                        }
                    }

                    if (start == 2)
                    {
                        input.RemoveAt(index1);
                        input.Insert(index1, paintingNumber2);
                        input.RemoveAt(index2);
                        input.Insert(index2, paintingNumber);
                    }
                }
                else if (comandArray[0] == "Insert")
                {
                    int place = int.Parse(comandArray[1]);
                    int paintingNumber = int.Parse(comandArray[2]);

                    if (place + 1 <= input.Count)
                    {
                        input.Insert(place + 1, paintingNumber);
                    }
                }
                else if (comandArray[0] == "Reverse")
                {
                    input.Reverse();
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", input));

        }
    }
}
