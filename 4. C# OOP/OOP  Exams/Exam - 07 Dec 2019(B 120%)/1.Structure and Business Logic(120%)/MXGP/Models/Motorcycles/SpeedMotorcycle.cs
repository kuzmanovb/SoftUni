using System;

using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 125.0;
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, CUBIC_CENTIMETERS)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
