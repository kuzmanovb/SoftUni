using SUS.HTTP;
using SUS.MvcFramework;

using Git.Services;
using Git.ViewModels.Users;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            var userId = this.usersService.GetUserId(username, password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("The username must be between 5 and 20 characters");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("The password must be between 6 and 20 characters");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("The password and the confirmed password do not match");
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return this.Error("This email already exists");
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Error("This username already exists");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.SignOut();
            return this.Redirect("/");
        }

    }
}
