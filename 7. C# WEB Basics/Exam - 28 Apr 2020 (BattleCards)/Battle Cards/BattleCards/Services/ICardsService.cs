using BattleCards.Models;
using BattleCards.ViewModels;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardModel input);

        void AddCardToUser(string userId, int cardId);

        ICollection<CardViewModel> GetAllCard();
        
        ICollection<CardViewModel> GetUserCollection(string userId);

        void RemoveCard(string userId, int cardId);
        
        void AddToMyCollectionCard(string userId, int cardId);


    }
}
