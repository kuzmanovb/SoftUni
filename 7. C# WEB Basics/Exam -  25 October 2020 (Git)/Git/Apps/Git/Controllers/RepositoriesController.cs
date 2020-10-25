using System;

using SUS.HTTP;
using SUS.MvcFramework;

using Git.Services;
using Git.ViewModels.Repositories;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var allRepo = this.repositoriesService.GetAllRepositories();

            return this.View(allRepo);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }


        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (name.Length < 3 || name.Length> 10)
            {
                return this.Error("Name must be between 3 and 10 characters");
            }

            var userId = this.GetUserId();

            var newCreateRepositoryModel = new CreateRepositoryModel
            {
                Name = name,
                CreatedOn = DateTime.Now,
                IsPublic = repositoryType == "Public" ? true : false,
                OwnerId = userId
            };

            this.repositoriesService.CreateRepository(newCreateRepositoryModel);


            return this.Redirect("/Repositories/All");
        }
    }
}
