using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {

            var listFollowersComment = new Dictionary<string, int>();
            var listFollowersLike = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Log out")
            {
                string[] inputArr = input.Split(": ");
                string command = inputArr[0];
                string user = inputArr[1];

                if (command == "New follower")
                {
                    CheckUser(listFollowersComment, listFollowersLike, user);
                }
                else if (command == "Like")
                {
                    int count = int.Parse(inputArr[2]);
                    
                    CheckUser(listFollowersComment, listFollowersLike, user);
                    
                    listFollowersLike[user] += count;
                }
                else if (command == "Comment")
                {
                    CheckUser(listFollowersComment, listFollowersLike, user);
                   
                    listFollowersComment[user] += 1;
                }
                else if (command == "Blocked")
                {
                    if (listFollowersComment.ContainsKey(user))
                    {
                        listFollowersComment.Remove(user);
                        listFollowersLike.Remove(user);
                    }
                    else
                    {
                        Console.WriteLine($"{user} doesn't exist.");
                    }
                }
                input = Console.ReadLine();
            }

            listFollowersLike = listFollowersLike.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine($"{listFollowersLike.Count} followers");

            foreach (var item in listFollowersLike)
            {
                string curentUser = item.Key;
                int sum = item.Value + listFollowersComment[curentUser];
                Console.WriteLine($"{curentUser}: {sum}");
            }
        }

        private static void CheckUser(Dictionary<string, int> listFollowersComment, Dictionary<string, int> listFollowersLike, string user)
        {
            if (!listFollowersComment.ContainsKey(user) && !listFollowersLike.ContainsKey(user))
            {
                listFollowersComment.Add(user, 0);
                listFollowersLike.Add(user, 0);
            }
        }
    }
}
