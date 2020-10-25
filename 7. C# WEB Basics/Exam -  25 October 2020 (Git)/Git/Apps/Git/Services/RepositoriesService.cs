using System.Linq;
using System.Collections.Generic;

using Git.Data;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateRepository(CreateRepositoryModel input)
        {
            var newReposotory = new Repository
            {
                Name = input.Name,
                CreatedOn = input.CreatedOn,
                IsPublic = input.IsPublic,
                OwnerId = input.OwnerId
            };

            this.db.Repositories.Add(newReposotory);
            this.db.SaveChanges();

            return newReposotory.Id;

        }

        public ICollection<RepositoryModel> GetAllRepositories()
        {
            var allRepositories = this.db.Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new RepositoryModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("g"),
                    CommitsCount = r.Commits.Count
                }).ToArray();

            return allRepositories;

        }

        public string GetNameById(string id)
        {
            return this.db.Repositories.Where(r => r.Id == id).Select(r => r.Name).FirstOrDefault();
        }
    }
}
