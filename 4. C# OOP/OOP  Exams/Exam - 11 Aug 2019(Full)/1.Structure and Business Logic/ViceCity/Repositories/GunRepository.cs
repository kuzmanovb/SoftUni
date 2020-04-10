using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;
        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            var check = models.FirstOrDefault(m => m == model);
            if(check == null)
            {
                models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public IGun FirstGun()
        {
            return models.FirstOrDefault();
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}
