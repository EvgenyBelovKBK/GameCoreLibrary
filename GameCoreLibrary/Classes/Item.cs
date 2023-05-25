﻿using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Classes
{
    public class Item : ObjectStats,ITierable
    {
        public int Cost { get; }
        public string Name {get; set; }
        public Tier Tier { get; set; }
        public ItemType Type { get; }
        public Item(Dictionary<string, int> stats, ItemType type, int cost, Tier rarity, string name) :base(stats)
        {
            Type = type;
            Stats = stats;
            Cost = cost;
            Tier = rarity;
            Name = name;
        }
    }
}
