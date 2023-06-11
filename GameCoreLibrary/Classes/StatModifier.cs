using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCoreLibrary.Enums;

namespace GameCoreLibrary.Classes
{
    public class StatModifier
    {
        public StatModifierPower Power { get; set; }
        public StatModifierRange Range { get; set; }
        public KeyValuePair<string, double> Stat { get; set; }

        public StatModifier(StatModifierPower power, StatModifierRange range, KeyValuePair<string, double> stat)
        {
            Power = power;
            Range = range;
            Stat = stat;
        }

        public double ApplyLocal(double localValue)
        {
            return localValue * Stat.Value;
        }
    }
}
