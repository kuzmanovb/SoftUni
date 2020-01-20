using System;
using System.Linq;
using System.Collections.Generic;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        
        {
            var inputList = Console.ReadLine().Split().Select(int.Parse).ToList();

            var removeIndexSum = 0;

            while (inputList.Count > 0)
            {
                int indexForRemove = int.Parse(Console.ReadLine());

                int removeIndexValue = RemoveIndexValue(inputList, indexForRemove);

                removeIndexSum += removeIndexValue;

                for (int i = 0; i < inputList.Count; i++)
                {
                    
                    if (inputList[i] <= removeIndexValue)
                    {
                        int newIneger = inputList[i] + removeIndexValue;
                        inputList.Insert(i, newIneger);
                        inputList.RemoveAt(i + 1);
                    }
                    else
                    {
                        int newIneger = inputList[i] - removeIndexValue;
                        inputList.Insert(i, newIneger);
                        inputList.RemoveAt(i + 1);
                    }
                }
            }

            Console.WriteLine(removeIndexSum);
        }
        static int RemoveIndexValue(List<int> inputList, int indexForRemove)
        {
            int removeIndexValue = 0;

            if (indexForRemove < 0)
            {
                removeIndexValue += inputList[0];
                int endNumber = inputList[inputList.Count - 1];
                inputList.RemoveAt(0);
                inputList.Insert(0, endNumber);
            }
            else if (indexForRemove > inputList.Count - 1)
            {
                removeIndexValue += inputList[inputList.Count - 1];
                inputList.RemoveAt(inputList.Count - 1);
                inputList.Add(inputList[0]);
            }
            else
            {
                removeIndexValue += inputList[indexForRemove];
                inputList.RemoveAt(indexForRemove);
            }

            return removeIndexValue;
        }
    }
}
