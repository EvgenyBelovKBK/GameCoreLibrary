using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;
using System.Numerics;

namespace GameCoreLibrary.Classes
{
    public abstract class Character : ObjectStats
    {
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; } = 0;
        public int NextLevelXp { get; set; } = 100;
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public Dictionary<string, int> BaseStats { get; }
        public Class Class { get; set; }

        protected Character(string name, int level, Class _class, Inventory inventory, Dictionary<string, int> stats, int gold = 0) : base(stats)
        {
            Gold = gold;
            Name = name;
            Class = _class;
            Level = level;
            Inventory = inventory;
            BaseStats = new Dictionary<string, int>(Stats);
            this.AddStats(Class.BaseStats, true);
            this.AddStats(BalanceConstants.BaseCharacterStats, true);

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

        

        
    }

    public static class CharacterExtensions
    {
        public static bool IsDead(this Character character)
        {
            return character.Stats[StatName.Hp] <= 0;
        }

        /// <returns>Is lifesteal > 0 applied</returns>
        public static bool ApplyLifesteal(this Character character, int damageDealt)
        {
            //Reverse lifesteal is OFF
            if (character.Stats[StatName.LifestealPercent] <= 0)
                return false;
            var onePercentOfDamage = (double)damageDealt / 100;
            var lifesteal = onePercentOfDamage * character.Stats[StatName.LifestealPercent];
            var hp = character.Stats[StatName.Hp];
            var maxHp = character.Stats[StatName.TotalHp];

            if (hp + lifesteal > maxHp)
                lifesteal = maxHp - hp;

            character.Stats[StatName.Hp] += (int)lifesteal; 
            return true;
        }

        public static void AddStats(this Character character, Dictionary<string, int> statsToAdd,bool withBase = false)
        {
            foreach (var stat in statsToAdd)
            {
                character.Stats[stat.Key] += stat.Value;
                if (withBase)
                    character.BaseStats[stat.Key] += stat.Value;
            }
        }

        public static void ReCalculateStats(this Character character, IEnumerable<Item>? items = null)
        {
            var currentHp = character.Stats[StatName.Hp];
            character.Stats = new Dictionary<string, int>(character.BaseStats)
            {
                [StatName.Hp] = currentHp
            };

            if (items != null)
            {
                foreach (var item in items)
                {
                    character.AddStats(item.Stats);
                }
            }

            if (character.Stats[StatName.Hp] > character.Stats[StatName.TotalHp])
                character.Stats[StatName.Hp] = character.Stats[StatName.TotalHp];
        }

        /// <returns>Is new level</returns>
        public static bool AddXp(this Character character, int xpAmount)
        {
            character.Xp += xpAmount;
            if (character.Xp >= character.NextLevelXp)
            {
                character.LvlUp();
                return true;
            }

            return false;
        }

        private static void LvlUp(this Character character)
        {
            character.NextLevelXp = (int)(character.NextLevelXp +
                                          ((BalanceConstants.BaseNextLevelXpAmount + character.Level) *
                                           Math.Pow(character.Level, BalanceConstants.NextLevelXpMultiplier)));
            //TODO
        }
    }
}
