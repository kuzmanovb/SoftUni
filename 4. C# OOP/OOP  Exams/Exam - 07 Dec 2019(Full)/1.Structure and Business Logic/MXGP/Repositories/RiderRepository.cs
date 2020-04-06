using System.Linq;

using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }

        public override bool Remove(IRider model)
        {
            return Models.Remove(model);
        }
    }
}
