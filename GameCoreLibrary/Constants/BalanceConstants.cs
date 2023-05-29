using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLibrary.Constants
{
    public static class BalanceConstants
    {
        #region Combat

        public static readonly double DamageAfterBlockMultiplier = 0.60;

        //mult * (damage * damage) / armor + mult * damage
        //Less value - less damage taken, more value - more damage taken through armor
        public static readonly double RawDamageToArmorMult = 3;

        #endregion

        #region Level

        public static readonly double NextLevelXpMultiplier = 2;
        public static readonly double BaseNextLevelXpAmount = 20;

        #endregion

        #region Other

        public static readonly Dictionary<string, double> StatsCaps = new()
        {
            { StatName.EvadeChance, 85 },
            { StatName.MagicResistance, 75 },
            { StatName.BlockChance, 90 },
            { StatName.LifestealPercent, 50 }
        };

        #endregion

        
    }
}
