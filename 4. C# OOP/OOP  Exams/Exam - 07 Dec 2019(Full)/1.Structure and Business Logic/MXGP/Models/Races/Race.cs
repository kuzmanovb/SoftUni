using System;
using System.Collections.Generic;

using MXGP.Utilities.Messages;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.riders = new List<IRider>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }
        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }
        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderInvalid));
            }
            else if (rider.Motorcycle == null)
            {
                throw new ArgumentException(string.Format(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name)));
            }
            else if (riders.Contains(rider))
            {
                throw new ArgumentException(string.Format(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name)));
            }

            riders.Add(rider);
        }
    }
}
