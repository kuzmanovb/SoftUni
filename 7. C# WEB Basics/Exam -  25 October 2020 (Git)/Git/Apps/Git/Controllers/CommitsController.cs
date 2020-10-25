using SUS.HTTP;
using SUS.MvcFramework;

using Git.Services;
using Git.ViewModels.Commits;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly ICommitsService commitsService;

        public CommitsController(IRepositoriesService repositoriesService, ICommitsService commitsService)
        {
            this.repositoriesService = repositoriesService;
            this.commitsService = commitsService;
        }
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var commitView = new CommittCreateMode
            {
                Id = id,
                Name = this.repositoriesService.GetNameById(id)
            };

            return this.View(commitView);
        }


        [HttpPost]
        public HttpResponse Create(string id, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (description.Length < 5)
            {
                return this.Error("Description must be more than 4 characters");
            }

            var userId = this.GetUserId();

            this.commitsService.CreateCommit(description, userId, id);

            return this.Redirect("/Repositories/All");
        }
       
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.GetUserId();

            var allComments = this.commitsService.GetAllCommits(userId);

            return this.View(allComments);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.commitsService.DeleteComitById(id);

            return this.Redirect("/Commits/All");
        }




    }
}
