using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Classes
{
    public class Enemy : Character,ITierable
    {
        public Tier Tier { get; set; }


        public Enemy(string name, int level, Class _class, Inventory inventory, Dictionary<string, double> baseStats, int gold = 0) : base(name, level, _class, inventory, baseStats, gold)
        {
        }
    }
}
