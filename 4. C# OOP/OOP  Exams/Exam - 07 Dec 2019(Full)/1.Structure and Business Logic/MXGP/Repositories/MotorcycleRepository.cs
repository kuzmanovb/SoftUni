using System.Linq;

using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Model == name);
        }

        public override bool Remove(IMotorcycle model)
        {
            return Models.Remove(model);
        }
    }
}
