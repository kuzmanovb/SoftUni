using BattleCards.Models;
using BattleCards.Services;
using BattleCards.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardService;

        public CardsController(ICardsService cardService)
        {
            this.cardService = cardService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardModel input)
        {
            if (input.Name.Length < 5 || input.Name.Length > 15)
            {
                return this.Error("Name must be between 5 and 15");
            }

            if (string.IsNullOrEmpty(input.Image))
            {
                return this.Error("Image URL can not be null or empty");
            }

            if (string.IsNullOrEmpty(input.Keyword))
            {
                return this.Error("Keyword can not be null or empty");
            }

            if (input.Attack < 0)
            {
                return this.Error("Attack can not be negative");
            } 
            
            if (input.Health < 0)
            {
                return this.Error("Health can not be negative");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length > 200)
            {
                return this.Error("Description can not be null, empty or more than 200 charectar ");
            }

            var cardId = this.cardService.AddCard(input);
            var userId = this.User;

            this.cardService.AddCardToUser(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

           var cards = this.cardService.GetAllCard();


            return this.View(cards);

        }


        public HttpResponse Collection()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.User;
            var collection = this.cardService.GetUserCollection(userId);

            return this.View(collection);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.User;
            this.cardService.AddCardToUser(userId, cardId);

            return this.Redirect("/Cards/Collection");

        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }


            var userId = this.User;

            this.cardService.RemoveCard(userId, cardId);


            return this.Redirect("/Cards/Collection");


        }

    }
}
