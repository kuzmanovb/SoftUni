using System;
using System.Linq;

using MXGP.IO;
using MXGP.Core.Contracts;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ConsoleReader consoleReader;
        private ConsoleWriter consoleWriter;
        private ChampionshipController championshipController;
        public Engine()
        {
            this.consoleReader = new ConsoleReader();
            this.consoleWriter = new ConsoleWriter();
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            var input = consoleReader.ReadLine().Split().ToArray();

            while (input[0] != "End")
            {
                var command = input[0];
                try
                {
                    if (command == "CreateRider")
                    {
                        string nameRider = input[1];

                        consoleWriter.WriteLine(championshipController.CreateRider(nameRider));
                    }

                    else if (command == "CreateMotorcycle")
                    {
                        string motorcycleType = input[1];
                        string model = input[2];
                        int horsePower = int.Parse(input[3]);

                        consoleWriter.WriteLine(championshipController.CreateMotorcycle(motorcycleType, model, horsePower));
                    }

                    else if (command == "AddMotorcycleToRider")
                    {
                        string riderName = input[1];
                        string motorcycleName = input[2];

                        consoleWriter.WriteLine(championshipController.AddMotorcycleToRider(riderName, motorcycleName));
                    }

                    else if (command == "AddRiderToRace")
                    {
                        string raceName = input[1];
                        string riderName = input[2];

                        consoleWriter.WriteLine(championshipController.AddRiderToRace(raceName, riderName));
                    }

                    else if (command == "CreateRace")
                    {
                        string name = input[1];
                        int laps = int.Parse(input[2]);

                        consoleWriter.WriteLine(championshipController.CreateRace(name, laps));
                    }

                    else if (command == "StartRace")
                    {
                        string name = input[1];

                        consoleWriter.WriteLine(championshipController.StartRace(name));
                    }

                }
                catch (Exception m)
                {
                    consoleWriter.WriteLine(m.Message);
                }
                finally
                {
                    input = consoleReader.ReadLine().Split().ToArray();
                }

            }
        }
    }
}
