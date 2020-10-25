using System.Collections.Generic;

using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitsService
    {
        string CreateCommit(string description, string creatorId, string repositoryId);

        ICollection<CommitViewModel> GetAllCommits(string id);

        void DeleteComitById(string id);



    }
}
