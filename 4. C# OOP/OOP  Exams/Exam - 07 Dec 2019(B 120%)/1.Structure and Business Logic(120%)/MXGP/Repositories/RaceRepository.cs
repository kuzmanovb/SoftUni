using System.Linq;

using MXGP.Models.Races.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }

        public override bool Remove(IRace model)
        {
            return Models.Remove(model);
        }
    }
}
