namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using System.Globalization;

    using Newtonsoft.Json;

    using Data;
    using VaporStore.XMLHelper;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var curentGame = context.Genres
                            .ToList()
                            .Where(g => genreNames.Contains(g.Name))
                            .Select(g => new GameByGenresDTO
                            {
                                Id = g.Id,
                                Genre = g.Name,
                                Games = g.Games
                                        .Where(ga => ga.Purchases.Any())
                                        .Select(r => new GameToGenresDTO
                                        {
                                            Id = r.Id,
                                            Title = r.Name,
                                            Developer = r.Developer.Name,
                                            Tags = string.Join(", ", r.GameTags.Select(t => t.Tag.Name).ToList()),
                                            Players = r.Purchases.Count()

                                        })
                                        .OrderByDescending(p => p.Players)
                                        .ThenBy(i => i.Id)
                                        .ToList(),
                                TotalPlayers = g.Games.SelectMany(x => x.Purchases).Count()
                            })
                            .OrderByDescending(p => p.TotalPlayers)
                            .ThenBy(i => i.Id)
                            .ToList();

            var curentGameToJSON = JsonConvert.SerializeObject(curentGame, Formatting.Indented);
            return curentGameToJSON;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {

            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var userPurchases = context.Users
                                .ToList()
                                .Where(p => p.Cards.Any(x => x.Purchases.Any()))
                                .Select(p => new UserPurchasesDTO
                                {
                                    Username = p.Username,
                                    Purchases = context.Purchases
                                               .ToList()
                                               .Where(x => x.Card.User.Username == p.Username && x.Type == purchaseTypeEnum)
                                               .OrderBy(d => d.Date)
                                               .Select(y => new PurchasesDTO
                                               {
                                                   Card = y.Card.Number,
                                                   Cvc = y.Card.Cvc,
                                                   Date = y.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                                   Game = new GameDTO
                                                   {
                                                       Title = y.Game.Name,
                                                       Genre = y.Game.Genre.Name,
                                                       Price = y.Game.Price
                                                   }
                                               })
                                               .ToList(),
                                    TotalSpent = context.Purchases
                                                 .ToList()
                                                 .Where(u => u.Card.User.Username == p.Username && u.Type == purchaseTypeEnum)
                                                 .Sum(s => s.Game.Price)
                                })
                                .Where(p => p.Purchases.Count > 0)
                                .OrderByDescending(t => t.TotalSpent)
                                .ThenBy(u => u.Username)
                                .ToList();

            var userPurchasesXML = XMLConverter.Serialize(userPurchases, "Users");

            return userPurchasesXML;

        }
    }
}