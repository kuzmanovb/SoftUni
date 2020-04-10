using System.Linq;
using System.Collections.Generic;

using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Models.Presents.Contracts;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> models;
        public PresentRepository()
        {

            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.models.AsReadOnly();

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return models.Remove(model);
        }
    }
}
