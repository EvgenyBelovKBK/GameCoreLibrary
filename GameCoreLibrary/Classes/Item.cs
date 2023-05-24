﻿using GameCoreLibrary.Enums;
using GameCoreLibrary.Interfaces;

namespace GameCoreLibrary.Classes
{
    public class Item : ObjectStats,ITierable
    {
        public int Cost { get; }
        public string Name {get; set; }
        public Tiers Tier { get; set; }
        public ItemType Type { get; }
        public Ability? ItemAbility { get; set; }
        public Item(Dictionary<string, int> stats, ItemType type, int cost, Tiers rarity, string name,
            Ability? itemAbility = null) :base(stats)
        {
            Type = type;
            Stats = stats;
            Cost = cost;
            Tier = rarity;
            Name = name;
            ItemAbility = itemAbility;
        }
    }
}