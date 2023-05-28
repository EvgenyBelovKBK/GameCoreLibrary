using GameCoreLibrary.Constants;

namespace GameCoreLibrary.Classes
{
    public abstract class ObjectStats
    {
        public Dictionary<string, double> Stats { get; set; }

        protected ObjectStats(Dictionary<string, double> stats)
        {
            Stats = new Dictionary<string, double>(stats);
        }

    }
}
