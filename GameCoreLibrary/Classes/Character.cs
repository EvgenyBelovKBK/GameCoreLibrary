using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public abstract class Character : ObjectStats
    {
        public int Gold { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public Dictionary<string, int> BaseStats { get; }
        public Race Race { get; set; }

        protected Character(Race race, Inventory inventory, int gold, string name, int maxHp,
            int damage, int armor, int lifestealPercent, int criticalStrikeChance, int blockChance,
            int evadeChance) : base(maxHp, damage, armor, lifestealPercent, criticalStrikeChance, blockChance,
            evadeChance)
        {
            Gold = gold;
            Name = name;
            Race = race;
            Inventory = inventory;
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
                CalculateStatsFromItemsAndTalents(Inventory.Items);
            };
            BaseStats = new Dictionary<string, int>(Stats);
        }

        public void CalculateStatsFromItemsAndTalents(IEnumerable<Item> items)
        {
            var currentHp = Stats[StatsConstants.HpStat];
            Stats = new Dictionary<string, int>(BaseStats);
            Stats[StatsConstants.HpStat] = currentHp;
            foreach (var item in items)
            {
                AddStats(item.Stats);
            }
            if (Stats[StatsConstants.HpStat] > Stats[StatsConstants.MaxHpStat])
                Stats[StatsConstants.HpStat] = Stats[StatsConstants.MaxHpStat];
        }

        public Character AddStats(Dictionary<string, int> statsToAdd,bool withBase = false)
        {
            foreach (var stat in statsToAdd)
            {
                Stats[stat.Key] += stat.Value;
                if (withBase)
                    BaseStats[stat.Key] += stat.Value;
            }

            return this;
        }
    }

    public static class CharacterExtensions
    {
        public static bool IsDead(this Character character)
        {
            return character.Stats[StatsConstants.HpStat] <= 0;
        }
    }
}
