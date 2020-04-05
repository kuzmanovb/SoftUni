using System.Collections.Generic;

using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly List<T> Models;
        public Repository()
        {
            this.Models = new List<T>();
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return Models.AsReadOnly();
        }

        public abstract T GetByName(string name);

        public abstract bool Remove(T model);
    }
}
