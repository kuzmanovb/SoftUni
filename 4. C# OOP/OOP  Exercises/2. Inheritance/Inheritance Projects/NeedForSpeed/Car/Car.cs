using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Car
{
    public class Car : Vehicle
    {
        private double DefaultFuelConsumption => 3.00;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption { get => this.DefaultFuelConsumption; set => this.FuelConsumption = DefaultFuelConsumption; }

        public override void Drive(double kilometers)
        {
            base.Fuel -= this.FuelConsumption * kilometers;
        }

    }
}
