
namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int ENERGY = 100;
        public HappyDwarf(string name)
            : base(name, ENERGY)
        {
        }
    }
}
