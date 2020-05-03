using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; }

        public int Happiness
        {
            get => happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get => energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                energy = value;
            }
        }

        public int ProcedureTime { get; set; }
        public string Owner { get; set; } = "Service";
        public bool IsBought { get; set; } = false;
        public bool IsChipped { get; set; } = false;
        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return String.Format(OutputMessages.RobotInfo, this.GetType().Name, this.Name, this.Happiness,this.Energy);
        }
    }
}