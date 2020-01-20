using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var startSongs = Console.ReadLine().Split(", ");

            var songQueue = new Queue<string>(startSongs);

            while (songQueue.Any())
            {
                var command = Console.ReadLine();
                if (command[0] == 'A')
                {
                    var song = command.Substring(4);
                    if (!songQueue.Contains(song))
                    {
                        songQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command[0] == 'P')
                {
                    songQueue.Dequeue();
                }
                else if (command[0] == 'S')
                {
                    Console.WriteLine(string.Join(", ",songQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
