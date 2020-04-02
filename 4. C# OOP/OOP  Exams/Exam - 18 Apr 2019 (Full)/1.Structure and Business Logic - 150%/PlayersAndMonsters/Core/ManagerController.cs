namespace PlayersAndMonsters.Core
{

    using System.Text;

    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class ManagerController : IManagerController
    {
        private CardFactory cardFactory;
        private CardRepository cardRepository;
        private PlayerFactory playerFactory;
        private PlayerRepository playerRepository;
        private BattleField battleField;

        public string CostantMassages { get; private set; }

        public ManagerController()
        {
            this.cardFactory = new CardFactory();
            this.cardRepository = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.playerRepository = new PlayerRepository();
            this.battleField = new BattleField();

        }

        public string AddPlayer(string type, string username)
        {
            var curentPlayer = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(curentPlayer);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type , username);
        }

        public string AddCard(string type, string name)
        {
            var curedCard = cardFactory.CreateCard(type, name);
            cardRepository.Add(curedCard);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = playerRepository.Find(attackUser);
            IPlayer enemyPlayer = playerRepository.Find(enemyUser);
            battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            
            foreach (var player in playerRepository.Players)
            {

                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));

            }

            return sb.ToString().TrimEnd();
        }
    }
}
