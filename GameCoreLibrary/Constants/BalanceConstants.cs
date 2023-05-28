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

        public static readonly double DamageAfterBlockMultiplier = 0.40;

        public static readonly Func<double, double, double> ArmorDamageMitigation = (damage, armor) =>
        {
            if (damage <= armor)
                return damage / (armor / damage);
            else
                return 1;            
        };

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
