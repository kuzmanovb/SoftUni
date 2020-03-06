using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Motorcycle
{
    class RaceMotorcycle : Motorcycle
    {
        private double DefaultFuelConsumption => 8.00;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption { get => this.DefaultFuelConsumption; set => this.FuelConsumption = this.DefaultFuelConsumption; }

        public override void Drive(double kilometers)
        {
            base.Fuel -= this.FuelConsumption * kilometers;
        }

    }
}
