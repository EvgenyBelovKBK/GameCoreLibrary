using GameCoreLibrary.Constants;

namespace GameCoreLibrary.Classes
{
    public abstract class ObjectStats
    {
        public Dictionary<string, int> Stats { get; set; }

        protected ObjectStats(Dictionary<string, int> stats)
        {
            Stats = new Dictionary<string, int>(stats);
        }

    }
}
