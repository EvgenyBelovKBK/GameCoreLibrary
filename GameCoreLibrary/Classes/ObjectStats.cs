using GameCoreLibrary.Constants;

namespace GameCoreLibrary.Classes
{
    public abstract class ObjectStats
    {
        public Dictionary<string, int> Stats { get; set; }

        protected ObjectStats(int maxHp, int damage, int armor, int lifestealPercent, int criticalStrikeChance,int blockChance,int evadeChance)
        {
            Stats = new Dictionary<string, int>
            {
                {StatsConstants.MaxHpStat, maxHp},
                {StatsConstants.HpStat, maxHp},
                {StatsConstants.DamageStat, damage},
                {StatsConstants.ArmorStat, armor},
                {StatsConstants.LifestealStat, lifestealPercent},
                {StatsConstants.CritChanceStat, criticalStrikeChance},
                {StatsConstants.BlockChanceStat, blockChance},
                {StatsConstants.EvadeChanceStat, evadeChance}
            };
        }

        protected ObjectStats(Dictionary<string, int> stats)
        {
            Stats = new Dictionary<string, int>(stats);
        }

    }
}
