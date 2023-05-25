using GameCoreLibrary.Classes;
using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Services
{
    public class FightingService
    {
        private readonly NumbersRandomGenerator _randomGenerator;

        public FightingService(NumbersRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        private int CalculateFinalDamage(int damage, int criticalStrikeChance, int targetArmor,int targetBlockChance,int targetEvadeChance,out FightResult fightResult)
        {
            var isCrit = _randomGenerator.IsRolled(criticalStrikeChance);
            var isEvade = _randomGenerator.IsRolled(targetEvadeChance);
            var isBlock = _randomGenerator.IsRolled(targetBlockChance);
            if (isEvade)
            {
                fightResult = new FightResultBuilder().SetEvasion();
                return 0;
            }
            fightResult = new FightResultBuilder().SetDamage(isCrit);
            var damageAfterCritRoll = isCrit ? damage * BalanceConstants.CritMultiplier : damage;
            var finalDamage = damageAfterCritRoll - targetArmor;

            if (isBlock)
            {
                fightResult = new FightResultBuilder().SetBlock();
                finalDamage *= BalanceConstants.DamageAfterBlockMultiplier;
            }
            finalDamage = finalDamage < 0 ? 0 : finalDamage;
            return (int)finalDamage;
        }

        public void CalculateFight(Player player, Enemy enemy, out bool isEnemyDied, out bool isPlayerDied)
        {
            isEnemyDied = false;
            isPlayerDied = false;

            var playerDamageToEnemy = CalculateFinalDamage(player.Stats[StatName.Damage],
                player.Stats[StatName.CritChance], enemy.Stats[StatName.Armor],
                enemy.Stats[StatName.BlockChance], enemy.Stats[StatName.EvadeChance],
                out var playerFightResult);
            var enemyDamageToPlayer = CalculateFinalDamage(enemy.Stats[StatName.Damage],
                enemy.Stats[StatName.CritChance], player.Stats[StatName.Armor],
                player.Stats[StatName.BlockChance], player.Stats[StatName.EvadeChance],
                out var enemyFightResult);

            //TODO
            if (true)
            {
                PlayerAction(player, enemy, playerDamageToEnemy, playerFightResult);
                if (enemy.IsDead())
                {
                    isEnemyDied = true;
                    return;
                }

                EnemyAction(enemy, player, enemyDamageToPlayer, enemyFightResult);
                if (player.IsDead())
                {
                    isPlayerDied = true;
                }
            }
        }


        private void PlayerAction(Player player,Enemy enemy,int playerDamageToEnemy, FightResult playerFightResult)
        {
            enemy.Stats[StatName.Hp] -= playerDamageToEnemy;
            if (playerFightResult.AttackOutcome == FightAction.CriticalStrike)
            {
                //TODO
            }
            var isLifestealed =  player.ApplyLifesteal(playerDamageToEnemy);
            if (isLifestealed)
            {
                //TODO
            }

        }

        private void EnemyAction( Enemy enemy, Player player,int enemyDamageToPlayer,FightResult enemyFightResult)
        {
            player.Stats[StatName.Hp] -= enemyDamageToPlayer;
            if (enemyFightResult.AttackOutcome == FightAction.CriticalStrike)
            {
                //TODO
            }

            enemy.ApplyLifesteal(enemyDamageToPlayer);
        }
    }
}
