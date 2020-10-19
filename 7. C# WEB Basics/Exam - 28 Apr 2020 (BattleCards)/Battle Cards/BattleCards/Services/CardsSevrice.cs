using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsSevrice : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsSevrice(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardModel input)
        {

            var newCard = new Card
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description
            };

            this.db.Cards.Add(newCard);
            this.db.SaveChanges();

            return newCard.Id;
        }

        public void AddCardToUser(string userId, int cardId)
        {
            if (string.IsNullOrEmpty(userId) && cardId < 1)
            {
                return;
            }

            var checkForUserCard = this.db.UserCards.Any(c => c.CardId == cardId && c.UserId == userId);

            if (checkForUserCard == true)
            {
                return;
            }


            var newUserCard = new UserCard { CardId = cardId, UserId = userId };





            db.UserCards.Add(newUserCard);
            db.SaveChanges();
        }

        public void AddToMyCollectionCard(string userId, int cardId)
        {
            db.UserCards.Add(new UserCard { CardId = cardId, UserId = userId });
            db.SaveChanges();
        }

        public ICollection<CardViewModel> GetAllCard()
        {
            return this.db.Cards.
                Select(c => new CardViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.ImageUrl,
                    Keyword = c.Keyword,
                    Attack = c.Attack,
                    Health = c.Health,
                    Description = c.Description

                })
                .ToArray();
        }

        public ICollection<CardViewModel> GetUserCollection(string userId)
        {
            var cardsToUser = this.db.UserCards
                .Where(u => u.UserId == userId)
                .Select(c => new CardViewModel
                {
                    Id = c.Card.Id,
                    Name = c.Card.Name,
                    Image = c.Card.ImageUrl,
                    Keyword = c.Card.Keyword,
                    Attack = c.Card.Attack,
                    Health = c.Card.Health,
                    Description = c.Card.Description

                })
                .ToArray();

            return cardsToUser;

        }

        public void RemoveCard(string userId, int cardId)
        {
            var curentUserCard = this.db.UserCards.FirstOrDefault(c => c.CardId == cardId && c.UserId == userId);
            db.UserCards.Remove(curentUserCard);
            db.SaveChanges();
        }

        

    }
}
