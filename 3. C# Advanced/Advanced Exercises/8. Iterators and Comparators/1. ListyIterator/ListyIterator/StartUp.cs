using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var firstInpur = Console.ReadLine().Split().ToList();
            ListyIterator<string> newlistyIterator =  new ListyIterator<string>(firstInpur.Skip(1).ToList());
           
            var command = Console.ReadLine();
            
            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(newlistyIterator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(newlistyIterator.HasNext());
                }
                else if (command == "Print")
                {
                    newlistyIterator.Print();
                }
                
                command = Console.ReadLine();
            }

        }


    }
}
