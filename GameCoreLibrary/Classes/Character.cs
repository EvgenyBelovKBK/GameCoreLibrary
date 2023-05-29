using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;
using System.Numerics;

namespace GameCoreLibrary.Classes
{
    public abstract class Character : ObjectStats
    {
        public int Gold { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public Class Class { get; }

        // Some Stats increase(ex. lvlup, subclass selection) should be forever baked into character, 
        // so when something happens in-game(inventory change, base stat modifiers etc) and Stats need recalculating,
        // BaseStats will have these baked values saved and recalculation will happen on top of BaseStats
        private Dictionary<string, double> BaseStats { get; }
        private Dictionary<string, double> BaseLvlUpStatsIncrease { get; } = CharConstants.BaseLvlUpStatsIncrease;

        protected Character(string name, int level, Class _class, Inventory inventory, Dictionary<string, double> stats,
            int gold = 0) : base(stats)
        {
            Gold = gold;
            Name = name;
            Class = _class;
            Level = level;
            Inventory = inventory;
            BaseStats = new Dictionary<string, double>(Stats);

            Inventory.Items.CollectionChanged += (sender, args) =>
            {
                if (Inventory.Items.Any(x => x.Type == ItemType.TwoHandedWeapon))
                {
                    Inventory.ItemRestrictions[ItemType.OneHandedWeapon] = 0;
                    Inventory.ItemRestrictions[ItemType.TwoHandedWeapon] = 1;
                }

                else if (Inventory.Items.Any(x => x.Type == ItemType.OneHandedWeapon))
                {
                    Inventory.ItemRestrictions[ItemType.TwoHandedWeapon] = 0;
                    Inventory.ItemRestrictions[ItemType.OneHandedWeapon] = 2;
                }
                else
                {
                    Inventory.ItemRestrictions = new Dictionary<ItemType, int>(ItemConstants.DefaultItemRestrictions);
                }

                this.ReCalculateStats(Inventory.Items);
            };
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

        //Stats from attributes are NOT baked into character, they are always calculated
        private void AddStatsFromAttributes(Dictionary<string, double> stats)
        {
            var filteredStats = stats.Where(x => CharConstants.AttrStatsIncrease.ContainsKey(x.Key))
                                                        .ToDictionary(k => k.Key, v => v.Value));
            foreach (var attributeStat in filteredStats)
            {
                var attributeStatIncrease = CharConstants.AttrStatsIncrease[attributeStat.Key];
                foreach (var statIncrease in attributeStatIncrease)
                {
                    Stats[statIncrease.Key] += statIncrease.Value * attributeStat.Value;
                }
            }
        }

        public void ReCalculateStats(IEnumerable<Item> items)
        {
            var currentHp = Stats[StatName.Hp];
            Stats = new Dictionary<string, double>(BaseStats)
            {
                [StatName.Hp] = currentHp
            };

            AddStatsFromAttributes(Stats);

            foreach (var item in items)
            {
                AddStats(item.Stats);
            }

            if (Stats[StatName.Hp] > Stats[StatName.TotalHp])
                Stats[StatName.Hp] = Stats[StatName.TotalHp];
        }
    }
}
