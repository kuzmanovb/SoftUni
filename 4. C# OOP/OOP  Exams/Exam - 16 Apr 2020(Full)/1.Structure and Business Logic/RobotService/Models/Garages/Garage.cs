using System;
using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots;
        public Garage()
        {
            robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;
        public void Manufacture(IRobot robot)
        {
            if (Robots.Count >= 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            robots[robotName].Owner = ownerName;
            robots[robotName].IsBought = true;
            robots.Remove(robotName);
        }
    }
}
