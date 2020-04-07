using System.Linq;
using System.Collections.Generic;

using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            var checkAstronaut = models.FirstOrDefault(a => a == model);
            if (checkAstronaut == null)
            {
                models.Add(model);
            }
        }

        public IAstronaut FindByName(string name)
        {
            return models.FirstOrDefault(a => a.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return models.Remove(model);
        }
    }
}
