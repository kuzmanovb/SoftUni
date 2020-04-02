using System.Linq;
using System.Collections.Generic;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> models;
        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.models.AsReadOnly();

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return models.FirstOrDefault(d => d.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            return models.Remove(model);
        }
    }
}
