using System;
using System.Linq;

using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;


namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            IncreasePointsAndHealthBeginner(attackPlayer, enemyPlayer);

            AddBonusPointsFromDeck(attackPlayer, enemyPlayer);

            while (true)
            {
                var attackPlayerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerDamagePoints);
                if (enemyPlayer.IsDead)
                {
                    break; ;
                }

                var enemyPlayerDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerDamagePoints);
                if (attackPlayer.IsDead)
                {
                    break; ;
                }
            }

        }

        private static void AddBonusPointsFromDeck(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            var healthFromAttackDeck = attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            var healthFromEnemyDeck = enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            attackPlayer.Health += healthFromAttackDeck;
            enemyPlayer.Health += healthFromEnemyDeck;
        }

        private static void IncreasePointsAndHealthBeginner(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            
            }
            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
