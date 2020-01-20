using System;
using System.Collections.Generic;
using System.Linq;

namespace Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> adventure = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Retire!")
            {
                string[] commandArray = input.Split(" - ");
                
                if (commandArray[0] == "Start")
                {
                    string quest = commandArray[1];
                    if (!adventure.Contains(quest))
                    {
                        adventure.Add(quest);
                    }
                }
                else if (commandArray[0] == "Complete")
                {
                    string quest = commandArray[1];
                    if (adventure.Contains(quest))
                    {
                        adventure.Remove(quest);
                    }
                }
                else if (commandArray[0] == "Side Quest")
                {
                    string[] sideArray = commandArray[1].Split(":");

                    string quest = sideArray[0];
                    string sideQuest = sideArray[1];

                    if (adventure.Contains(quest) && !adventure.Contains(sideQuest))
                    {
                        int indexQuest = adventure.IndexOf(quest);

                        adventure.Insert(indexQuest+1, sideQuest);
                    }
                }
                else if (commandArray[0] == "Renew")
                {
                    string quest = commandArray[1];
                    if (adventure.Contains(quest))
                    {
                        int indexQuest = adventure.IndexOf(quest);
                        
                        string questForRemove = adventure[indexQuest];

                        adventure.RemoveAt(indexQuest);
                        adventure.Add(questForRemove);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", adventure));
        }
    }
}
