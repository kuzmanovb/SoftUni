using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "merge")
                {
                    MergeInputList(inputList, commandArray);
                }
                else if (commandArray[0] == "divide")
                {
                    DivideInputList(inputList, commandArray);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", inputList));
        }
        static void MergeInputList(List<string> inputList, string[] commandArray)
        {

            int startIndex = int.Parse(commandArray[1]);
            int endIndex = int.Parse(commandArray[2]);
            // Check index
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            else if (startIndex > inputList.Count - 1)
            {
                startIndex = inputList.Count - 1;
            }
            if (endIndex < 0)
            {
                endIndex = 0;
            }
            else if (endIndex > inputList.Count - 1)
            {
                endIndex = inputList.Count - 1;
            }

            string merge = null;

            for (int i = startIndex; i <= endIndex; i++)
            {
                merge += inputList[i];
            }

            inputList.Insert(startIndex, merge);

            for (int a = endIndex + 1; a >= startIndex + 1; a--)
            {
                inputList.RemoveAt(a);
            }
        }

        static void DivideInputList(List<string> inputList, string[] commandArray)
        {

            int index = int.Parse(commandArray[1]);
            string divideString = inputList[index];
            int divider = int.Parse(commandArray[2]);
            int partition = divideString.Length / divider;
            int partitionRest = divideString.Length % divider;

            int insertIndex = 0;

            List<string> medial = new List<string>();

            string currentString = null;


            for (int i = 0; i < divideString.Length - partitionRest; i += partition)
            {
                currentString += divideString.Substring(i, partition);

                int endString = i + partition;

                if (divideString.Length - partitionRest == endString)
                {
                    currentString += divideString.Substring(divideString.Length - partitionRest);
                }

                medial.Insert(insertIndex, currentString);
                insertIndex++;
                currentString = "";
            }

            inputList.RemoveAt(index);
            inputList.InsertRange(index, medial);
        }
    }
}
