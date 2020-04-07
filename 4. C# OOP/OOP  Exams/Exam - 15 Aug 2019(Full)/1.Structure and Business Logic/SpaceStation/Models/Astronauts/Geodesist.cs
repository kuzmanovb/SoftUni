
namespace SpaceStation.Models
{
    public class Geodesist : Astronaut
    {
        private const int OXYGEN = 50;
        public Geodesist(string name) 
            : base(name, OXYGEN)
        {
        }
    }
}
