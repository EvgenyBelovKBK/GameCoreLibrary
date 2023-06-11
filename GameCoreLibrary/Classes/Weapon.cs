using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }

        public Weapon(Dictionary<string, double> baseStats, ItemType type,WeaponType weaponType, int cost, Tier rarity, string name) : base(baseStats, type, cost, rarity, name)
        {
            WeaponType = weaponType;
        }
    }
}
