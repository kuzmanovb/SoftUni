using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            if (type == "Magic")
            {
                return new MagicCard(name);
            }
            else if (type == "Trap")
            {
                return new TrapCard(name);
            }
            else
            {
                return null;
            }
        }
    }
}
