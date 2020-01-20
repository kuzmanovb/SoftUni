using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            var userSend = new Dictionary<string, int>();
            var userReceiver = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputArr = input.Split("=");
                string command = inputArr[0];

                if (command == "Add")
                {
                    string nameUser = inputArr[1];
                    int send = int.Parse(inputArr[2]);
                    int received = int.Parse(inputArr[3]);
                    if (!userSend.ContainsKey(nameUser))
                    {
                        userSend.Add(nameUser, send);
                        userReceiver.Add(nameUser, received);
                    }
                }
                else if (command == "Message")
                {
                    string nameSender = inputArr[1];
                    string nameReceiver = inputArr[2];

                    if (userSend.ContainsKey(nameSender) && userSend.ContainsKey(nameReceiver))
                    {
                        userSend[nameSender] += 1;
                        userReceiver[nameReceiver] += 1;
                        if (userSend[nameSender] + userReceiver[nameSender] >= capacity)
                        {
                            userSend.Remove(nameSender);
                            userReceiver.Remove(nameSender);
                            Console.WriteLine($"{nameSender} reached the capacity!");
                        }
                        if (userSend[nameReceiver] + userReceiver[nameReceiver] >= capacity)
                        {
                            userSend.Remove(nameReceiver);
                            userReceiver.Remove(nameReceiver);
                            Console.WriteLine($"{nameReceiver} reached the capacity!");
                        }
                    }
                }
                else if (command == "Empty")
                {
                    string nameUser = inputArr[1];

                    if (nameUser == "All")
                    {
                        userSend.Clear();
                        userReceiver.Clear();
                    }
                    else if (userSend.ContainsKey(nameUser))
                    {
                        userSend.Remove(nameUser);
                        userReceiver.Remove(nameUser);
                    }
                }

                input = Console.ReadLine();
            }

            userReceiver = userReceiver.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: {userReceiver.Count}");

            foreach (var item in userReceiver)
            {
                int sum = item.Value + userSend[item.Key];

                Console.WriteLine($"{item.Key} - {sum}");
            }

        }
    }
}
