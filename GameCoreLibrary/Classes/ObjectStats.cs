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
            ApplyModifiers(true);
        }

        protected void ApplyModifiers(bool fromBase = false)
        {
            foreach (var statModifier in StatModifiers.Where(x => x.Power == StatModifierPower.Additive))
            {
                var key = statModifier.Stat.Key;
                Stats[key] = statModifier.GetModified(fromBase ? BaseStats[key] : Stats[key]);
            }

            foreach (var statModifier in StatModifiers.Where(x => x.Power == StatModifierPower.Multiplicative))
            {
                var key = statModifier.Stat.Key;
                Stats[key] = statModifier.GetModified(fromBase ? BaseStats[key] : Stats[key]);
            }
        }

        public void AddStatModifiers(params StatModifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                var modifierIndex = StatModifiers.FindIndex(x => x.Stat.Key == modifier.Stat.Key);
                if (modifier.Power == StatModifierPower.Additive && modifierIndex != -1)
                {
                    var currentModifier = StatModifiers[modifierIndex].Stat;
                    StatModifiers[modifierIndex].Stat = new (currentModifier.Key, currentModifier.Value + modifier.Stat.Value);
                }
                else
                {
                    StatModifiers.Add(modifier);
                }
            }
        }
    }
}
