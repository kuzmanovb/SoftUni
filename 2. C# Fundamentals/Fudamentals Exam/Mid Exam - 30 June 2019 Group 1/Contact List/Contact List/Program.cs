using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contactsList = Console.ReadLine().Split().ToList();

            string[] input = Console.ReadLine().Split();

            while (true)
            {
                if (input[0] == "Add")
                {
                    string contact = input[1];
                    int index = int.Parse(input[2]);

                    if (!contactsList.Contains(contact))
                    {
                        contactsList.Add(contact);
                    }
                    else
                    {
                        bool validateIndex = index >= 0 && index < contactsList.Count;

                        if (validateIndex)
                        {
                            contactsList.Insert(index, contact);
                        }
                    }
                }
                else if (input[0] == "Remove")
                {
                    int index = int.Parse(input[1]);

                    bool validateIndex = index >= 0 && index < contactsList.Count;

                    if (validateIndex)
                    {
                        contactsList.RemoveAt(index);
                    }
                }
                else if (input[0] == "Export")
                {
                    int startIndex = int.Parse(input[1]);
                    int count = int.Parse(input[2]);

                    int endIndex = startIndex + count;

                    if (endIndex > contactsList.Count)
                    {
                        endIndex = contactsList.Count;
                    }

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        Console.Write(contactsList[i] + " ");
                    }
                    Console.WriteLine();
                }
                if (input[0] == "Print")
                {
                    if (input[1] == "Normal")
                    {
                        Console.Write("Contacts: ");
                        Console.WriteLine(string.Join(" ", contactsList));
                        Console.WriteLine();
                        break;
                    }
                    else if (input[1] == "Reversed")
                    {
                        contactsList.Reverse();
                        Console.Write("Contacts: ");
                        Console.WriteLine(string.Join(" ", contactsList));
                        Console.WriteLine();
                        break;
                    }
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
