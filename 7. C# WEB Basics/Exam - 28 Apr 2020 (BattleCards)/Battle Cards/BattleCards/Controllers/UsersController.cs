using BattleCards.Services;
using BattleCards.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
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
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserModel input)
        {

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Cards/All");
            }

            return this.Redirect("/Users/Login");

        }


        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RgisterUserModel input)
        {
            
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
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }

    }
}
