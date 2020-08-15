namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Globalization;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;
    
	using Data;
    using VaporStore.XMLHelper;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var gameFromJSON = JsonConvert.DeserializeObject<List<ImportGamesDTO>>(jsonString);
			var sb = new StringBuilder();

			var gameToImport = new List<Game>();
			var developersToImport = new List<Developer>();
			var genreToImport = new List<Genre>();
			var tagToImport = new List<Tag>();
			var gameTagToImport = new List<GameTag>();



            foreach (var g in gameFromJSON)
            {
                if (!IsValid(g))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

                if (g.Tags.Count == 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var curentDeveloper = developersToImport.FirstOrDefault(d => d.Name == g.Developer);

                if (curentDeveloper == null)
                {
					var newDeveloper = new Developer { Name = g.Developer };
					developersToImport.Add(newDeveloper);
					curentDeveloper = newDeveloper;
                }

				var curentGenre = genreToImport.FirstOrDefault(e => e.Name == g.Genre);

				if (curentGenre == null)
				{
					var newGenre = new Genre { Name = g.Genre };
					genreToImport.Add(newGenre);
					curentGenre = newGenre;
				}

				var newGame = new Game
				{
					Name = g.Name,
					Price = g.Price,
					ReleaseDate = DateTime.ParseExact(g.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
					Developer = curentDeveloper,
					Genre = curentGenre
				};


				var tagsCount = 0;

                foreach (var t in g.Tags)
                {

					var curentTag = tagToImport.FirstOrDefault(x => x.Name == t);

                    if (curentTag == null)
                    {
						var newTag = new Tag { Name = t };
						curentTag = newTag;
						tagToImport.Add(newTag);

                    }
						var newGameTag = new GameTag { Game = newGame, Tag = curentTag };
						gameTagToImport.Add(newGameTag);
						tagsCount++;
                }

				sb.AppendLine($"Added {g.Name} ({g.Genre}) with {tagsCount} tags");

            }

			context.Developers.AddRange(developersToImport);
			context.Genres.AddRange(genreToImport);
			context.Games.AddRange(gameToImport);
			context.Tags.AddRange(tagToImport);
			context.GameTags.AddRange(gameTagToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();

		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var usersCardsFromJSON = JsonConvert.DeserializeObject<List<ImportUsersCardsDTO>>(jsonString);

			var sb = new StringBuilder();

			var usersToImport = new List<User>();
			var cardsToImport = new List<Card>();

            foreach (var uc in usersCardsFromJSON)
            {
                if (!IsValid(uc))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var newUser = new User
				{
					FullName = uc.FullName,
					Username = uc.Username,
					Email = uc.Email,
					Age = uc.Age

				};

				var curentCards = new List<Card>();
				var checkForError = false;

                foreach (var c in uc.Cards)
                {
                    if (!IsValid(c))
                    {
						sb.AppendLine("Invalid Data");
						checkForError = true;
						break;
					}

					Object cardTypeRes;
					bool isCardTypeValid = Enum.TryParse(typeof(CardType), c.Type, out cardTypeRes);

                    if (!isCardTypeValid)
                    {
						sb.AppendLine("Invalid Data");
						checkForError = true;
						break;
					}

					var newCard = new Card
					{
						Number = c.Number,
						Cvc = c.CVC,
						Type = (CardType)cardTypeRes,
						User = newUser
					};

					curentCards.Add(newCard);
                }

                if (!checkForError)
                {
					usersToImport.Add(newUser);
					cardsToImport.AddRange(curentCards);

					sb.AppendLine($"Imported {uc.Username} with { curentCards.Count} cards");
                }
            }

			context.Users.AddRange(usersToImport);
			context.Cards.AddRange(cardsToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var purchasesFromXML = XMLConverter.Deserializer<ImportPurchasesDTO>(xmlString, "Purchases");
			var sb = new StringBuilder();

			var purchasesToImport = new List<Purchase>();

            foreach (var p in purchasesFromXML)
            {
                if (!IsValid(p))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Object purchaseTypeRes;
				bool isCardTypeValid = Enum.TryParse(typeof(PurchaseType), p.Type, out purchaseTypeRes);

                if (!isCardTypeValid)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var curentCard = context.Cards.FirstOrDefault(c => c.Number == p.Card);
				var curentGame = context.Games.FirstOrDefault(g => g.Name == p.GameName);

                if (curentCard == null || curentCard == null)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var newPurchase = new Purchase
				{
					Type = (PurchaseType)purchaseTypeRes,
					ProductKey = p.ProductKey,
					Date = DateTime.ParseExact(p.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = curentCard,
					Game = curentGame
				};

				purchasesToImport.Add(newPurchase);

				sb.AppendLine($"Imported {curentGame.Name} for {curentCard.User.Username}");

			}

			context.Purchases.AddRange(purchasesToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}