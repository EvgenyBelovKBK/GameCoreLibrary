﻿using GameCoreLibrary.Classes;
using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Services
{
    public class FightingService
    {
        private readonly NumbersRandomGenerator _randomGenerator;

        private const double CRIT_MULTIPLIER = 1.65;
        private const double DAMAGE_AFTER_BLOCK_MULTIPLIER = 0.35;
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
            var damageAfterCritRoll = isCrit ? damage * CRIT_MULTIPLIER : damage;
            var finalDamage = damageAfterCritRoll - targetArmor;
            //Блокирование удара нивелирует 65% урона
            if (isBlock)
            {
                fightResult = new FightResultBuilder().SetBlock();
                finalDamage *= DAMAGE_AFTER_BLOCK_MULTIPLIER;
            }
            finalDamage = finalDamage < 0 ? 0 : finalDamage;
            return (int)finalDamage;
        }

        private int CalculateLifesteal(int finalDamage, int lifestealPercent,int currentHp, int maxHp)
        {
            //На данный момент негативного лайфстила решил не делать,если он понадобится то переделать!
            if (lifestealPercent <= 0)
                return 0;
            var onePercentOfDamage = (double)finalDamage / 100;
            var lifesteal = onePercentOfDamage * lifestealPercent;
            if (currentHp + lifesteal > maxHp)
                lifesteal = maxHp - currentHp;
            return (int)lifesteal;
        }

        public void CalculateFight(Player player,Enemy enemy,bool isPlayerTurn,out bool isEnemyDied,out bool isPlayerDied)
        {
            isEnemyDied = false;
            isPlayerDied = false;

            var playerDamageToEnemy = CalculateFinalDamage(player.Stats[StatsConstants.DamageStat],
                player.Stats[StatsConstants.CritChanceStat], enemy.Stats[StatsConstants.ArmorStat],
                enemy.Stats[StatsConstants.BlockChanceStat], enemy.Stats[StatsConstants.EvadeChanceStat],out var playerFightResult);
            var enemyDamageToPlayer = CalculateFinalDamage(enemy.Stats[StatsConstants.DamageStat],
                enemy.Stats[StatsConstants.CritChanceStat], player.Stats[StatsConstants.ArmorStat],
                player.Stats[StatsConstants.BlockChanceStat], player.Stats[StatsConstants.EvadeChanceStat], out var enemyFightResult);

            if (isPlayerTurn)
            {
                PlayerAction(player, enemy, playerDamageToEnemy, playerFightResult);
                if (CheckForDeath(enemy.Stats[StatsConstants.HpStat]))
                {
                    isEnemyDied = true;
                    return;
                }

                EnemyAction(enemy,player, enemyDamageToPlayer,enemyFightResult);
                if (CheckForDeath(player.Stats[StatsConstants.HpStat]))
                {
                    isPlayerDied = true;
                }
            }
            else
            {
                EnemyAction(enemy, player, enemyDamageToPlayer, enemyFightResult);
                if (CheckForDeath(player.Stats[StatsConstants.HpStat]))
                {
                    isPlayerDied = true;
                    return;
                }

                PlayerAction(player, enemy, playerDamageToEnemy,playerFightResult );
                if (CheckForDeath(enemy.Stats[StatsConstants.HpStat]))
                {
                    isEnemyDied = true;
                }
            }
        }


        private void PlayerAction(Player player,Enemy enemy,int playerDamageToEnemy, FightResult playerFightResult)
        {
            enemy.Stats[StatsConstants.HpStat] -= playerDamageToEnemy;
            if (playerFightResult.AttackOutcome == FightAction.CriticalStrike)
            {
                player.ActivateAbilities(ActiveAbilityType.PlayerCrit);
            }
            var playerLifesteal = CalculateLifesteal(playerDamageToEnemy,
                player.Stats[StatsConstants.LifestealStat],
                player.Stats[StatsConstants.HpStat],
                player.Stats[StatsConstants.MaxHpStat]);
            player.Stats[StatsConstants.HpStat] += playerLifesteal;
            if (playerLifesteal > 0)
            {
                player.ActivateAbilities(ActiveAbilityType.PlayerLifesteal);
            }

        }

        private void EnemyAction( Enemy enemy, Player player,int enemyDamageToPlayer,FightResult enemyFightResult)
        {
            player.Stats[StatsConstants.HpStat] -= enemyDamageToPlayer;
            if (enemyFightResult.AttackOutcome == FightAction.CriticalStrike)
            {
                player.ActivateAbilities(ActiveAbilityType.EnemyCrit);
            }
            var enemyLifesteal = CalculateLifesteal(enemyDamageToPlayer,
                enemy.Stats[StatsConstants.LifestealStat],
                enemy.Stats[StatsConstants.HpStat],
                enemy.Stats[StatsConstants.MaxHpStat]);
            enemy.Stats[StatsConstants.HpStat] += enemyLifesteal;
        }

        public bool CheckForDeath(int hp)
        {
            return hp <= 0;
        }

    }
}
