using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            foreach (var item in cards)
            {
                if (card.Name == item.Name)
                {
                    throw new ArgumentException($"Card {card.Name} already exists!");
                }
            }
            cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {

            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
           
                return this.cards.Remove(card);
               
        }
    }
}
