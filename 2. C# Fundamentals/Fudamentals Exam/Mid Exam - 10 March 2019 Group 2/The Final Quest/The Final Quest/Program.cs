using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split().ToList();

            string token = Console.ReadLine();

            while (token != "Stop")
            {
                string[] tokenArr = token.Split();

                if (tokenArr[0] == "Delete")
                {
                    int index = int.Parse(tokenArr[1]) + 1;
                    bool valid = index >= 0 && index < inputList.Count;
                    if (valid)
                    {
                        inputList.RemoveAt(index);
                    }
                }
                else if (tokenArr[0] == "Swap")
                {
                    string word1 = tokenArr[1];
                    string word2 = tokenArr[2];

                    if (inputList.Contains(word1) && inputList.Contains(word2))
                    {
                        int indexWord1 = inputList.IndexOf(word1);
                        int indexWord2 = inputList.IndexOf(word2);

                        inputList[indexWord1] = word2;
                        inputList[indexWord2] = word1;
                    }
                }
                else if (tokenArr[0] == "Put")
                {
                    string word = tokenArr[1];
                    int index = int.Parse(tokenArr[2]) - 1;
                    bool valid = index >= 0 && index <= inputList.Count;

                    if (valid)
                    {
                        inputList.Insert(index, word);
                    }
                }
                else if (tokenArr[0] == "Sort")
                {
                    inputList.Sort();
                    inputList.Reverse();
                }
                else if (tokenArr[0] == "Replace")
                {
                    string word1 = tokenArr[1];
                    string word2 = tokenArr[2];

                    if (inputList.Contains(word2))
                    {
                        int indexWord2 = inputList.IndexOf(word2);
                        inputList[indexWord2] = word1;
                    }
                }

                token = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
