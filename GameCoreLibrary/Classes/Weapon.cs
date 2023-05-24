using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }

        public Weapon(Dictionary<string, int> stats, ItemType type,WeaponType weaponType, int cost, Tiers rarity, string name) : base(stats, type, cost, rarity, name)
        {
            WeaponType = weaponType;
        }
    }
}
