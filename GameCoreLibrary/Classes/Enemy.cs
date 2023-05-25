using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Classes
{
    public class Enemy : Character,ITierable
    {
        public Tier Tier { get; set; }

        public Enemy(Tier tier, Race race, Class _class,  Inventory inventory, int level, int gold, string name,
            int maxHp, int damage, int armor, int lifestealPercent, int criticalStrikeChance, int blockChance = 0,
            int evadeChance = 0) : base(race, _class, inventory, level, gold, name, maxHp, damage,
            armor, lifestealPercent, criticalStrikeChance, blockChance, evadeChance)
        {
            Inventory = inventory;
            Tier = tier;
        }
    }
}
