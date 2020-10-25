using System;
using System.Linq;
using System.Collections.Generic;

using Git.Data;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateCommit(string description, string creatorId, string repositoryId)
        {
            var newCommit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.Now,
                CreatorId = creatorId,
                RepositoryId = repositoryId
            };

            this.db.Commits.Add(newCommit);
            this.db.SaveChanges();

            return newCommit.Id;
        
        }

        public void DeleteComitById(string id)
        {
            var currentCommit = this.db.Commits.FirstOrDefault(c => c.Id == id);

            this.db.Commits.Remove(currentCommit);
            this.db.SaveChanges();

        }

        public ICollection<CommitViewModel> GetAllCommits(string id)
        {
            var allCommits = this.db.Commits
                .Where(c => c.CreatorId == id)
                .Select(c => new CommitViewModel
                {
                    Id = c.Id,
                    NameRepository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("g")
                }).ToArray();

            return allCommits;
        }


    }
}
