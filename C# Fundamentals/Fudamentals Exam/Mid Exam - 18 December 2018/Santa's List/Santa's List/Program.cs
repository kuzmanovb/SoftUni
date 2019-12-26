using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kidsList = Console.ReadLine().Split("&").ToList();

            string input = Console.ReadLine();

            while (input != "Finished!")
            {
                string[] inputArray = input.Split();

                if (inputArray[0] == "Bad")
                {
                    string newKid = inputArray[1];

                    if (!kidsList.Contains(newKid))
                    {
                        kidsList.Insert(0, newKid);
                    }
                }
                else if (inputArray[0] == "Good")
                {
                    string kid = inputArray[1];

                    if (kidsList.Contains(kid))
                    {
                        kidsList.Remove(kid);
                    }
                }
                if (inputArray[0] == "Rename")
                {
                    string oldKid = inputArray[1];
                    string newKid = inputArray[2];

                    if (kidsList.Contains(oldKid))
                    {
                        int indexOldKid = kidsList.IndexOf(oldKid);
                        kidsList.Remove(oldKid);
                        kidsList.Insert(indexOldKid, newKid);
                    }
                }
                if (inputArray[0] == "Rearrange")
                {
                    string kid = inputArray[1];
                    

                    if (kidsList.Contains(kid))
                    {
                        kidsList.Remove(kid);
                        kidsList.Add(kid);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", kidsList));
        }
    }
}
