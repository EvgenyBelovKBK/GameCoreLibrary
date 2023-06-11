using GameCoreLibrary.Constants;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public abstract class ObjectStats
    {
        public Dictionary<string, double> Stats { get; set; } = new();
        public List<StatModifier> StatModifiers { get; set; }
        public int Level { get; set; }
        protected Dictionary<string, double> BaseStats { get; }

        protected ObjectStats(Dictionary<string, double> baseStats, int level, List<StatModifier>? statsModifiers = null)
        {
            Level = level;
            StatModifiers = statsModifiers ?? new();
            BaseStats = new Dictionary<string, double>(baseStats);
            ApplyLocalModifiers();
        }

        public void ApplyLocalModifiers()
        {
            foreach (var statModifier in StatModifiers)
            {
                var key = statModifier.Stat.Key;
                Stats[key] = statModifier.ApplyLocal(BaseStats[key]);
            }
        }
    }
}
