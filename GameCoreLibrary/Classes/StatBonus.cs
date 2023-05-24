namespace GameCoreLibrary.Classes
{
    public class StatBonus : ObjectStats,ITierable
    {
        public Tiers Tier { get; set; }
        public StatBonus(Tiers tier,Dictionary<string, int> stats) : base(stats)
        {
            Tier = tier;
        }


    }
}
