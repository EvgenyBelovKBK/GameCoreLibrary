using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Classes
{
    public class Enemy : Character,ITierable
    {
        public Tiers Tier { get; set; }
        public string AsciiArt { get; set; }

        public Enemy(Tiers tier, Race race,  Inventory inventory, int gold, string name,
            int maxHp, int damage, int armor, int lifestealPercent, int criticalStrikeChance, int blockChance = 0,
            int evadeChance = 0, string asciiArt = "") : base(race, inventory, gold, name, maxHp, damage,
            armor, lifestealPercent, criticalStrikeChance, blockChance, evadeChance)
        {
            Inventory = inventory;
            Tier = tier;
            AsciiArt = asciiArt;
        }
    }
}
