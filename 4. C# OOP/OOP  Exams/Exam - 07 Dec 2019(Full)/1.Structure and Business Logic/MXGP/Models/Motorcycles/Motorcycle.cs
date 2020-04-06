using System;

using MXGP.Utilities.Messages;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {

        private string model;
        private double cubicCentimeters;
        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;

        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }


        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            set
            {
                this.cubicCentimeters = value;
            }
        }


        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
