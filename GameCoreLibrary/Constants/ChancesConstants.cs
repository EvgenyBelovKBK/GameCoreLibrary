using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Constants
{
    public static class ChancesConstants
    {
        public static readonly Dictionary<Tier, Dictionary<Tier, int>> ShopChances = new Dictionary<Tier, Dictionary<Tier, int>>()
        {
            {
                Tier.Tier1 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,95 },
                    {Tier.Tier2,5 },
                    {Tier.Tier3,0 },
                    {Tier.Tier4,0 },
                    {Tier.Tier5,0 }
                } 
            },
            {
                Tier.Tier2 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,15 },
                    {Tier.Tier2,75 },
                    {Tier.Tier3,10 },
                    {Tier.Tier4,0 },
                    {Tier.Tier5,0 }
                }
            },
            {
                Tier.Tier3 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,0 },
                    {Tier.Tier2,20 },
                    {Tier.Tier3,75 },
                    {Tier.Tier4,5 },
                    {Tier.Tier5,0 }
                }
            },
            {
                Tier.Tier4 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,0 },
                    {Tier.Tier2,0 },
                    {Tier.Tier3,15 },
                    {Tier.Tier4,80 },
                    {Tier.Tier5,5 }
                }
            },
            {
                Tier.Tier5 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,0 },
                    {Tier.Tier2,0 },
                    {Tier.Tier3,0 },
                    {Tier.Tier4,10 },
                    {Tier.Tier5,80 }
                }
            },
        };


        public static readonly Dictionary<Tier, Dictionary<Tier, int>> EnemyChances = new Dictionary<Tier, Dictionary<Tier, int>>()
        {
            {
                Tier.Tier1 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,99 },
                    {Tier.Tier2,1 },
                    {Tier.Tier3,0 },
                    {Tier.Tier4,0 },
                    {Tier.Tier5,0 }
                }
            },
            {
                Tier.Tier2 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,15 },
                    {Tier.Tier2,83 },
                    {Tier.Tier3,2 },
                    {Tier.Tier4,0 },
                    {Tier.Tier5,0 }
                }
            },
            {
                Tier.Tier3 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,0 },
                    {Tier.Tier2,13 },
                    {Tier.Tier3,85 },
                    {Tier.Tier4,2 },
                    {Tier.Tier5,0 }
                }
            },
            {
                Tier.Tier4 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,0 },
                    {Tier.Tier2,0 },
                    {Tier.Tier3,5 },
                    {Tier.Tier4,93 },
                    {Tier.Tier5,2 }
                }
            },
            {
                Tier.Tier5 ,new Dictionary<Tier,int>()
                {
                    {Tier.Tier1,0 },
                    {Tier.Tier2,0 },
                    {Tier.Tier3,0 },
                    {Tier.Tier4,10 },
                    {Tier.Tier5,90 }
                }
            },
        };
    }
}
