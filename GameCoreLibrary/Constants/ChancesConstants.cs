﻿using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Constants
{
    public static class ChancesConstants
    {
        public static readonly Dictionary<Tiers, Dictionary<Tiers, int>> ShopChances = new Dictionary<Tiers, Dictionary<Tiers, int>>()
        {
            {
                Tiers.Tier1 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,95 },
                    {Tiers.Tier2,5 },
                    {Tiers.Tier3,0 },
                    {Tiers.Tier4,0 },
                    {Tiers.Tier5,0 }
                } 
            },
            {
                Tiers.Tier2 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,15 },
                    {Tiers.Tier2,75 },
                    {Tiers.Tier3,10 },
                    {Tiers.Tier4,0 },
                    {Tiers.Tier5,0 }
                }
            },
            {
                Tiers.Tier3 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,0 },
                    {Tiers.Tier2,20 },
                    {Tiers.Tier3,75 },
                    {Tiers.Tier4,5 },
                    {Tiers.Tier5,0 }
                }
            },
            {
                Tiers.Tier4 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,0 },
                    {Tiers.Tier2,0 },
                    {Tiers.Tier3,15 },
                    {Tiers.Tier4,80 },
                    {Tiers.Tier5,5 }
                }
            },
            {
                Tiers.Tier5 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,0 },
                    {Tiers.Tier2,0 },
                    {Tiers.Tier3,0 },
                    {Tiers.Tier4,10 },
                    {Tiers.Tier5,80 }
                }
            },
        };


        public static readonly Dictionary<Tiers, Dictionary<Tiers, int>> EnemyChances = new Dictionary<Tiers, Dictionary<Tiers, int>>()
        {
            {
                Tiers.Tier1 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,99 },
                    {Tiers.Tier2,1 },
                    {Tiers.Tier3,0 },
                    {Tiers.Tier4,0 },
                    {Tiers.Tier5,0 }
                }
            },
            {
                Tiers.Tier2 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,15 },
                    {Tiers.Tier2,83 },
                    {Tiers.Tier3,2 },
                    {Tiers.Tier4,0 },
                    {Tiers.Tier5,0 }
                }
            },
            {
                Tiers.Tier3 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,0 },
                    {Tiers.Tier2,13 },
                    {Tiers.Tier3,85 },
                    {Tiers.Tier4,2 },
                    {Tiers.Tier5,0 }
                }
            },
            {
                Tiers.Tier4 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,0 },
                    {Tiers.Tier2,0 },
                    {Tiers.Tier3,5 },
                    {Tiers.Tier4,93 },
                    {Tiers.Tier5,2 }
                }
            },
            {
                Tiers.Tier5 ,new Dictionary<Tiers,int>()
                {
                    {Tiers.Tier1,0 },
                    {Tiers.Tier2,0 },
                    {Tiers.Tier3,0 },
                    {Tiers.Tier4,10 },
                    {Tiers.Tier5,90 }
                }
            },
        };
    }
}
