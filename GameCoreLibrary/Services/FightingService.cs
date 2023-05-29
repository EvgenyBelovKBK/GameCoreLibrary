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

        private int CalculateFinalDamage(Character attacker, Character defender, out FightResult fightResult)
        {
            var isCrit = _randomGenerator.IsRolled(attacker.Stats[StatName.CritChance]);
            var isEvade = _randomGenerator.IsRolled(defender.Stats[StatName.EvadeChance]);
            var isBlock = _randomGenerator.IsRolled(defender.Stats[StatName.BlockChance]);
            if (isEvade)
            {
                fightResult = new FightResultBuilder().SetEvasion();
                return 0;
            }
            fightResult = new FightResultBuilder().SetDamage(isCrit);
            var damageAfterCritRoll = isCrit ? attacker.Stats[StatName.PhysDamage] * attacker.Stats[StatName.CritDamageMultiplier] :
                                               attacker.Stats[StatName.PhysDamage];
            if (isBlock)
            {
                fightResult = new FightResultBuilder().SetBlock();
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

            var playerDamageToEnemy = CalculateFinalDamage(player, enemy, out var playerFightResult);
            var enemyDamageToPlayer = CalculateFinalDamage(enemy, player, out var enemyFightResult);

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

        //mult * (damage * damage) / armor + mult * damage
        private double CalulatePhysDamageAfterArmor(double damage, double armor)
        {
            return BalanceConstants.RawDamageToArmorMult * (damage * damage) / armor + (BalanceConstants.RawDamageToArmorMult * damage);
        }
    }
}
