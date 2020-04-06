using System;

using MXGP.Models.Motorcycles;
using MXGP.Utilities.Messages;

namespace MXGP.Models
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450.0;
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, CUBIC_CENTIMETERS)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
