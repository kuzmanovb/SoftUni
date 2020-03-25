using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;


namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var input = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var commandName = input[0] + "Command";
            var arguments = input.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            var commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());
            if (commandType == null)
            {
                throw new ArgumentException("Invalid type");
            }

            var createIstance = (ICommand)Activator.CreateInstance(commandType);

            return createIstance.Execute(arguments);
        }
    }
}
