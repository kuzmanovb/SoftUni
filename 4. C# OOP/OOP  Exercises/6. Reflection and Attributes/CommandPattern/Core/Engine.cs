using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            var inputText = Console.ReadLine();

            try
            {
                var result = this.commandInterpreter.Read(inputText);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
