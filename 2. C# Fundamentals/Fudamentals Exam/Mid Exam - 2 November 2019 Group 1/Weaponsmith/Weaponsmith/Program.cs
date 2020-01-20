using System;
using System.Collections;
using System.Linq;

namespace Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            var weapon = Console.ReadLine().Split("|").ToList();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] inputArr = input.Split();

                if (inputArr[0] == "Move")
                {
                    if (inputArr[1] == "Left")
                    {
                        int indexLeft = int.Parse(inputArr[2]);

                        bool checkIndex = indexLeft > 0 && indexLeft < weapon.Count;

                        if (checkIndex)
                        {
                            string forMove = weapon[indexLeft];
                            weapon.Insert(indexLeft - 1, forMove);
                            weapon.RemoveAt(indexLeft + 1);
                        }
                    }
                    else if (inputArr[1] == "Right")
                    {
                        int indexRight = int.Parse(inputArr[2]);

                        bool checkIndex = indexRight >= 0 && indexRight < weapon.Count - 1;

                        if (checkIndex)
                        {
                            string forMove = weapon[indexRight];
                            weapon.Insert(indexRight + 2, forMove);
                            weapon.RemoveAt(indexRight);
                        }
                    }
                }
                else if (inputArr[0] == "Check")
                {
                    if (inputArr[1] == "Even")
                    {
                        for (int i = 0; i < weapon.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write(weapon[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    if (inputArr[1] == "Odd")
                    {
                        for (int i = 0; i < weapon.Count; i++)
                        {

                            if (i % 2 != 0)
                            {
                                Console.Write(weapon[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

                input = Console.ReadLine();
            }

            string result = string.Join("", weapon);
            
            Console.WriteLine($"You crafted {result}!");
           
        }
    }
}
