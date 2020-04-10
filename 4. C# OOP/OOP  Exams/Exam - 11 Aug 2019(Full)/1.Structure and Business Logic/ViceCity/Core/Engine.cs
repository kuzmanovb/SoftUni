using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private Controller controller;


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();

        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        var name = input[1];

                        writer.WriteLine(controller.AddPlayer(name));
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var name = input[2];

                        writer.WriteLine(controller.AddGun(type, name));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var name = input[1];

                        writer.WriteLine(controller.AddGunToPlayer(name));
                    }
                    else if (input[0] == "Fight")
                    {
                        writer.WriteLine(controller.Fight());
                    }            
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
