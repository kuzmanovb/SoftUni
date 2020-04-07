using System;

using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Astronauts.Contracts;


namespace SpaceStation.Models
{
    public abstract  class Astronaut : IAstronaut
    {
        private const int DECREASES_DXYGEN = 10;

        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }
        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0 )
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }
        public  bool CanBreath => this.Oxygen > 0;

        public IBag Bag => this.bag;

        public virtual void Breath()
        {
            if (this.Oxygen - DECREASES_DXYGEN < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= DECREASES_DXYGEN;
            }
        }
    }
}
