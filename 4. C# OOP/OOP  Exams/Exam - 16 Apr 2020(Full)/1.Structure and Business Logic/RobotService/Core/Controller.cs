using System;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Chip newChip;
        private TechCheck newTechCheck;
        private Rest newRest;
        private Work newWork;
        private Charge newCharge;
        private Polish newPolish;


        public Controller()
        {
            this.garage = new Garage();
            this.newChip = new Chip();
            this.newTechCheck = new TechCheck();
            this.newRest = new Rest();
            this.newWork = new Work();
            this.newCharge = new Charge();
            this.newPolish = new Polish();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot newRobot = null;

            if (robotType == "HouseholdRobot")
            {
                newRobot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                newRobot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                newRobot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            garage.Manufacture(newRobot);

            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var currentRobot = garage.Robots[robotName];
            newChip.DoService(currentRobot, procedureTime);

            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var currentRobot = garage.Robots[robotName];
            newTechCheck.DoService(currentRobot, procedureTime);

            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName)); 
            }

            var currentRobot = garage.Robots[robotName];
            newRest.DoService(currentRobot, procedureTime);

            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var currentRobot = garage.Robots[robotName];
            newWork.DoService(currentRobot, procedureTime);

            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var currentRobot = garage.Robots[robotName];
            newCharge.DoService(currentRobot, procedureTime);

            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var currentRobot = garage.Robots[robotName];
            newPolish.DoService(currentRobot, procedureTime);

            return  String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var currentRobot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);

            if (currentRobot.IsChipped)
            {
               return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

        }

        public string History(string procedureType)
        {
            if (procedureType == "Chip")
            {
                return newChip.History();
            }

            if (procedureType == "TechCheck")
            {
                return newTechCheck.History();
            }

            if (procedureType == "Rest")
            {
                return newRest.History();
            }

            if (procedureType == "Work")
            {
                return newWork.History();
            }

            if (procedureType == "Charge")
            {
                return newCharge.History();
            }

            if (procedureType == "Polish")
            {
                return newPolish.History();
            }

            return null;

        }
    }
}
