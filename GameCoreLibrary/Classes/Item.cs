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
        public Dictionary<string, double> Requirments { get; }
        public Item(Dictionary<string, double> baseStats, Dictionary<string, double> requirments, int level, ItemType type, int cost, Tier rarity, string name) :base(baseStats, level)
        {
            Type = type;
            Cost = cost;
            Tier = rarity;
            Name = name;
            Requirments = requirments;
        }

        public override void RecalculateStats()
        {
            ApplyModifiers(true);
        }
    }
}
