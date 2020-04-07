using System.Linq;
using System.Collections.Generic;

using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();
        public void Add(IPlanet model)
        {
            var checkPlanet = models.FirstOrDefault(p => p == model);
            if (checkPlanet == null)
            {
                models.Add(model);
            }
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }
    }
}
