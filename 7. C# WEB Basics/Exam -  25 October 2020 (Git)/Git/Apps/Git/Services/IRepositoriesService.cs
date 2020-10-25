using System.Collections.Generic;

using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {

        string CreateRepository(CreateRepositoryModel input);

        ICollection<RepositoryModel> GetAllRepositories();

        string GetNameById(string id);


    }
}
