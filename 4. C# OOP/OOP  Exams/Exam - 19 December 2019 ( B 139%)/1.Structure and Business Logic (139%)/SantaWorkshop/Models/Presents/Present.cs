using System;

using SantaWorkshop.Utilities.Messages;
using SantaWorkshop.Models.Presents.Contracts;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private string name;
        private int energyRequired;
        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }

        public void GetCrafted()
        {
            if (energyRequired - 10 < 0)
            {
                this.energyRequired = 0;
            }
            else
            {
                this.energyRequired -= 10;
            }
        }

        public bool IsDone() => this.energyRequired <= 0;
    }
}

