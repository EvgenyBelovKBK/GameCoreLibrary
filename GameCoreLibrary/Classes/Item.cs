using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Classes
{
    public class Item : ObjectStats,ITierable
    {
        public int Cost { get; }
        public string Name {get; set; }
        public Tier Tier { get; set; }
        public ItemType Type { get; }
        public Item(Dictionary<string, double> baseStats, int level, ItemType type, int cost, Tier rarity, string name) :base(baseStats, level)
        {
            Type = type;
            Cost = cost;
            Tier = rarity;
            Name = name;
        }
    }
}
