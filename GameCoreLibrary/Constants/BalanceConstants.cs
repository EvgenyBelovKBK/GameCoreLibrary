using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLibrary.Constants
{
    public static class BalanceConstants
    {
        public const double DamageAfterBlockMultiplier = 0.35;

        public const double CritMultiplier = 1.65;

        public const double NextLevelXpMultiplier = 2;
        public const double BaseNextLevelXpAmount = 20;

        public static readonly Dictionary<string, int> BaseCharacterStats = new()
        {
            { StatName.TotalHp, 100 },
            { StatName.Hp, 100 },
            { StatName.Intelligence, 5 },
            { StatName.Agility, 5 },
            { StatName.Strength, 5 },
            { StatName.Armor, 10 },
            { StatName.BlockChance, 0 },
            { StatName.CritChance, 5 },
            { StatName.Damage, 25 },
            { StatName.EvadeChance, 0 },
            { StatName.LifestealPercent, 0 },
            { StatName.CritDamageMultiplier, 150 },
        };
    }
}
