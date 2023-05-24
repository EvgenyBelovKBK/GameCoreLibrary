﻿using GameCoreLibrary.Constants;

namespace GameCoreLibrary.Classes
{
    public class Level
    {
        public int Number { get; }
        public string LevelName { get;}
        public List<Enemy> Enemies { get; set; }

        public Level(int number, string levelName, List<Enemy> enemies)
        {
            Number = number;
            LevelName = levelName;
            Enemies = new List<Enemy>();
            foreach (var enemy in enemies)
            {
                Enemies.Add(new Enemy(enemy.Tier,
                    enemy.Race,
                    enemy.Abilities,
                    enemy.Inventory,
                    enemy.Gold,
                    enemy.Name,
                    enemy.Stats[StatsConstants.HpStat],
                    enemy.Stats[StatsConstants.DamageStat],
                    enemy.Stats[StatsConstants.ArmorStat],
                    enemy.Stats[StatsConstants.LifestealStat],
                    enemy.Stats[StatsConstants.CritChanceStat],
                    enemy.Stats[StatsConstants.BlockChanceStat],
                    enemy.Stats[StatsConstants.EvadeChanceStat],
                    enemy.AsciiArt));
            }
        }
    }
}
