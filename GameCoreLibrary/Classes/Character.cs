using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;

namespace GameCoreLibrary.Classes
{
    public abstract class Character : ObjectStats
    {
        public int Gold { get; set; }
        public string Name { get; set; }
        private Inventory Inventory { get;}
        public Class Class { get; }

        private Dictionary<string, double> BaseLvlUpStatsIncrease { get; } = CharConstants.BaseLvlUpStatsIncrease;

        protected Character(string name, int level, Class _class, Inventory inventory, Dictionary<string, double> baseStats,
            int gold = 0) : base(baseStats, level)
        {
            Gold = gold;
            Name = name;
            Class = _class;
            Level = level;
            Inventory = inventory;
            RecalculateStats();
        }

        protected void LvlUp(int lvlAmount = 1)
        {
            Level += lvlAmount;
            AddStats(BaseLvlUpStatsIncrease, true);
            AddStats(
                lvlAmount == 1
                    ? Class.LvlUpStatsIncrease
                    : Class.LvlUpStatsIncrease.ToDictionary(k => k.Key, v => v.Value * lvlAmount), true);
            //TODO
        }

        public bool IsDead()
        {
            return Stats[StatName.Hp] <= 0;
        }

        /// <returns>True if lifesteal > 0 applied</returns>
        public bool ApplyLifesteal(int damageDealt)
        {
            //Reverse lifesteal is OFF
            if (Stats[StatName.LifestealPercent] <= 0)
                return false;
            var onePercentOfDamage = (double)damageDealt / 100;
            var lifesteal = onePercentOfDamage * Stats[StatName.LifestealPercent];
            var hp = Stats[StatName.Hp];
            var maxHp = Stats[StatName.TotalHp];

            if (hp + lifesteal > maxHp)
                lifesteal = maxHp - hp;

            Stats[StatName.Hp] += (int)lifesteal;
            return true;
        }

        public void AddStats(Dictionary<string, double> statsToAdd, bool withBase = false)
        {
            AddStatsFromAttributes(statsToAdd);
            foreach (var stat in statsToAdd)
            {
                Stats[stat.Key] += stat.Value;
                if (Stats[stat.Key] > BalanceConstants.StatsCaps[stat.Key])
                    Stats[stat.Key] = BalanceConstants.StatsCaps[stat.Key];
                if (withBase)
                    BaseStats[stat.Key] += stat.Value;
            }
        }

        public override void RecalculateStats()
        {
            var currentHp = Stats[StatName.Hp];
            Stats = new Dictionary<string, double>(BaseStats)
            {
                [StatName.Hp] = currentHp
            };

            AddStatsFromAttributes(Stats);

            foreach (var item in Inventory.Items)
            {
                AddStats(item.Stats);
            }

            ApplyModifiers();

            if (Stats[StatName.Hp] > Stats[StatName.TotalHp])
                Stats[StatName.Hp] = Stats[StatName.TotalHp];
        }

        //Stats from attributes are NOT baked into character, they are always calculated
        private void AddStatsFromAttributes(Dictionary<string, double> stats)
        {
            var filteredStats = stats.Where(x => CharConstants.AttrStatsIncrease.ContainsKey(x.Key))
                                     .ToDictionary(k => k.Key, v => v.Value);
            foreach (var attributeStat in filteredStats)
            {
                var attributeStatIncrease = CharConstants.AttrStatsIncrease[attributeStat.Key];
                foreach (var statIncrease in attributeStatIncrease)
                {
                    Stats[statIncrease.Key] += statIncrease.Value * attributeStat.Value;
                }
            }
        }
    }
}
