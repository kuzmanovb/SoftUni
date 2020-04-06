using System;
using System.Linq;

using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager manager;
        public Engine()
        {
            this.manager = new MachinesManager();
        }

        public void Run()
        {

            var input = Console.ReadLine().Split().ToArray();
           
            while (input[0] != "Quit")
            {

                try
                {
                    if (input[0] == "HirePilot")
                    {
                        var name = input[1];
                        Console.WriteLine(manager.HirePilot(name));
                    }
                    else if (input[0] == "PilotReport")
                    {
                        var name = input[1];
                        Console.WriteLine(manager.PilotReport(name));
                    }
                    else if (input[0] == "ManufactureTank")
                    {
                        var name = input[1];
                        var attack = double.Parse(input[2]);
                        var defense = double.Parse(input[3]);

                        Console.WriteLine(manager.ManufactureTank(name, attack, defense));
                    }
                    else if (input[0] == "ManufactureFighter")
                    {
                        var name = input[1];
                        var attack = double.Parse(input[2]);
                        var defense = double.Parse(input[3]);

                        Console.WriteLine(manager.ManufactureFighter(name, attack, defense));
                    }
                    else if (input[0] == "MachineReport")
                    {
                        var name = input[1];
                        Console.WriteLine(manager.MachineReport(name));
                    }
                    else if (input[0] == "AggressiveMode")
                    {
                        var name = input[1];
                        Console.WriteLine(manager.ToggleFighterAggressiveMode(name));
                    }
                    else if (input[0] == "DefenseMode")
                    {
                        var name = input[1];
                        Console.WriteLine(manager.ToggleTankDefenseMode(name));
                    }
                    else if (input[0] == "Engage")
                    {
                        var namePilot = input[1];
                        var nameMachine = input[2];
                        Console.WriteLine(manager.EngageMachine(namePilot, nameMachine));
                    }
                    else if (input[0] == "Attack")
                    {
                        var atacker = input[1];
                        var defender = input[2];
                        Console.WriteLine(manager.AttackMachines(atacker, defender));
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error:{e.Message}");

                }
                finally
                {
                    input = Console.ReadLine().Split().ToArray();
                }
            }
        }
    }
}
