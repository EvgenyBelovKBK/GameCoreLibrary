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

        private int CalculateFinalDamage(Character attacker, Character defender)
        {
            var isCrit = _randomGenerator.IsRolled(attacker.Stats[StatName.CritChance]);
            var isEvade = _randomGenerator.IsRolled(defender.Stats[StatName.EvadeChance]);
            var isBlock = _randomGenerator.IsRolled(defender.Stats[StatName.BlockChance]);
            if (isEvade)
            {
                return 0;
            }
            var damageAfterCritRoll = isCrit ? attacker.Stats[StatName.PhysDamage] * attacker.Stats[StatName.CritDamageMultiplier] :
                                               attacker.Stats[StatName.PhysDamage];
            if (isBlock)
            {
                damageAfterCritRoll *= BalanceConstants.DamageAfterBlockMultiplier;
            }

            var finalDamage = CalulatePhysDamageAfterArmor(damageAfterCritRoll, defender.Stats[StatName.Armor]);

            finalDamage = finalDamage < 0 ? 0 : finalDamage;
            return (int)finalDamage;
        }

        //TODO
        public void CalculateFight(Player player, Enemy enemy, out bool isEnemyDied, out bool isPlayerDied)
        {
            isEnemyDied = false;
            isPlayerDied = false;

            var playerDamageToEnemy = CalculateFinalDamage(player, enemy);
            var enemyDamageToPlayer = CalculateFinalDamage(enemy, player);

            //TODO
            if (true)
            {
                PlayerAction(player, enemy, playerDamageToEnemy);
                if (enemy.IsDead())
                {
                    isEnemyDied = true;
                    return;
                }

                EnemyAction(enemy, player, enemyDamageToPlayer);
                if (player.IsDead())
                {
                    isPlayerDied = true;
                }
            }
        }


        private void PlayerAction(Player player,Enemy enemy,int playerDamageToEnemy)
        {
            enemy.Stats[StatName.Hp] -= playerDamageToEnemy;
            var isLifestealed =  player.ApplyLifesteal(playerDamageToEnemy);
            if (isLifestealed)
            {
                //TODO
            }

        }

        private void EnemyAction( Enemy enemy, Player player,int enemyDamageToPlayer)
        {
            player.Stats[StatName.Hp] -= enemyDamageToPlayer;

            enemy.ApplyLifesteal(enemyDamageToPlayer);
        }

        //mult * (damage^2) / armor + mult * damage
        private double CalulatePhysDamageAfterArmor(double damage, double armor)
        {
            return BalanceConstants.RawDamageToArmorMult * (damage * damage) / armor + (BalanceConstants.RawDamageToArmorMult * damage);
        }
    }
}
