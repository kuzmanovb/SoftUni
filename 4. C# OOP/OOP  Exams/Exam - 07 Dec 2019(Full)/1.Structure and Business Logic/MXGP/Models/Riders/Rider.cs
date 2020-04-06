using System;

using MXGP.Utilities.Messages;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private IMotorcycle motorcycles;
        private int numberOfWins;
        public Rider(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }
        public IMotorcycle Motorcycle => this.motorcycles;

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate
        {
            get
            {
                if (motorcycles == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleMustBeNull);
            }

            this.motorcycles = motorcycle;
        }

        public void WinRace()
        {
            numberOfWins++;
        }
    }
}
