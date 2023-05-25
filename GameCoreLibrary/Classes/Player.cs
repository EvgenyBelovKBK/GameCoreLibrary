using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Player : Character
    {
        public Player(Race race, Class _class, Inventory inventory, int level, int gold, string name, int maxHp,
            int damage, int armor, int lifestealPercent, int criticalStrikeChance, int blockChance, int evadeChance) :
            base(race, _class, inventory, level, gold, name, maxHp, damage, armor, lifestealPercent, criticalStrikeChance,
                blockChance, evadeChance)
        {

        }
    }
}
