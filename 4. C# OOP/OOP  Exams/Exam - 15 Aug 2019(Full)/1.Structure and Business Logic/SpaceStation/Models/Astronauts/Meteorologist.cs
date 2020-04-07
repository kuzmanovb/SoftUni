
namespace SpaceStation.Models
{
    public class Meteorologist : Astronaut
    {
        private const int OXYGEN = 90;
        public Meteorologist(string name)
            : base(name, OXYGEN)
        {
        }
    }
}
