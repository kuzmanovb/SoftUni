
namespace SpaceStation.Models
{
    public class Biologist : Astronaut
    {
        private const int OXYGEN = 70;
        private const int DECREASES_DXYGEN = 5;
        public Biologist(string name) 
            : base(name, OXYGEN)
        {
        }

        public override void Breath()
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
